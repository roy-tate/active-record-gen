using System;
using System.Collections.Generic;
using System.Text;

namespace ActiveRecordGenerator.CodeGen
{
	public class DbFieldInfo
	{
		#region Private_Variables

		private string _Column_Name;
		private string _Column_Default;
		private bool _Is_Nullable; // YES or NO
		private int _Character_Maximum_Length;
		private int _Numeric_Precision;
		private int _Numeric_Scale;
		private string _Data_Type;

		private DbForeignKeyInfo _DbForeignKeyInfo;

		#endregion

		public DbFieldInfo(
			string p_Column_Name,
			string p_Column_Default,
			bool p_Is_Nullable,
			int p_Character_Maximum_Length,
			int p_Numeric_Precision,
			int p_Numeric_Scale,
			string p_Data_Type
		)
		{
			_Column_Name = p_Column_Name;
			_Column_Default = p_Column_Default;
			_Is_Nullable = p_Is_Nullable;
			_Character_Maximum_Length = p_Character_Maximum_Length;
			_Numeric_Precision = p_Numeric_Precision;
			_Numeric_Scale = p_Numeric_Scale;
			_Data_Type = p_Data_Type;
		}

		#region Public_Properties

		public string Column_Name 
		{
			get { return _Column_Name; }
		}

		public string Column_Default 
		{
			get { return _Column_Default; }
		}

		public bool Is_Nullable 
		{
			get { return _Is_Nullable; } 
		}

		public int Character_Maximum_Length 
		{
			get { return _Character_Maximum_Length; } 
		}

		public int Numeric_Precision 
		{
			get { return _Numeric_Precision; } 
		}

		public int Numeric_Scale 
		{
			get { return _Numeric_Scale; } 
		}

		public string Data_Type
		{
			get { return _Data_Type; }
			set { _Data_Type = value.ToLowerInvariant(); }
		}

		public DbForeignKeyInfo ForeignKeyInfo
		{
			get { return _DbForeignKeyInfo; }
			set { _DbForeignKeyInfo = value; }
		}

		#endregion

		#region Business_Method

		public bool IsPrimaryKey()
		{
			if (Is_Nullable) return false;
			if (Column_Name.Equals("ID")) return true;
			return false;
		}

		public bool IsForeignKey()
		{
			if (Column_Name.EndsWith("_ID")) return true;
			return false;
		}

		public string GetPropertyName()
		{
			if (this.IsForeignKey())
				return Column_Name.Substring(0, Column_Name.Length - 3);
			else
				return Column_Name;
		}

		public string GetPrivateVariableName()
		{
			if (IsPrimaryKey())
				return "_" + Column_Name.ToLowerInvariant();
			else if (this.IsForeignKey())
				// subtracting 4 characters accounts for starting at index 1, and excluding suffix of "_ID"
				return "_" + Column_Name.Substring(0, 1).ToLowerInvariant() + Column_Name.Substring(1, Column_Name.Length - 4);
			else
				return "_" + Column_Name.Substring(0, 1).ToLowerInvariant() + Column_Name.Substring(1);
		}

		public string GetSqlType()
		{
			if ((Data_Type.Equals("bigint"))
				|| (Data_Type.Equals("int"))
				|| (Data_Type.Equals("smallint"))
				|| (Data_Type.Equals("tinyint"))
				|| (Data_Type.Equals("bit"))
				|| (Data_Type.Equals("datetime"))
				|| (Data_Type.Equals("smalldatetime")) 
				|| (Data_Type.Equals("money"))
				|| (Data_Type.Equals("smallmoney"))
				|| (Data_Type.Equals("float"))
				|| (Data_Type.Equals("real"))
				|| (Data_Type.Equals("ntext"))
				|| (Data_Type.Equals("text"))
				|| (Data_Type.Equals("image"))
				|| (Data_Type.Equals("uniqueidentifier"))
			)
				return Data_Type;

			if ((Data_Type.Equals("char")) 
				|| (Data_Type.Equals("varchar"))
				|| (Data_Type.Equals("nchar"))
				|| (Data_Type.Equals("nvarchar"))
				|| (Data_Type.Equals("binary"))
				|| (Data_Type.Equals("varbinary"))
			)
				return String.Format("{0}({1})", Data_Type, Character_Maximum_Length);

			if ((Data_Type.Equals("decimal"))
				|| (Data_Type.Equals("numeric"))
)
				return String.Format("{0}({1},{2})", Data_Type, Numeric_Scale, Numeric_Precision);

			throw new Exception("Unexpected data type: " + Data_Type);
		}

		public string GetNetType()
		{
			if (this.IsForeignKey()) return Column_Name.Substring(0, Column_Name.Length - 3);

			string sqlType = Data_Type;
			// the suffix will add "?" at end if .net type is not a class and field is nullable
			string suf = (Is_Nullable) ? "?" : "";

			if (sqlType.Equals("bigint")) return "long" + suf;
			if (sqlType.Equals("int")) return "int" + suf;
			if (sqlType.Equals("smallint")) return "short" + suf;
			if (sqlType.Equals("tinyint")) return "byte" + suf;
			if (sqlType.Equals("bit")) return "bool" + suf;
			if (sqlType.Equals("decimal")) return "System.Decimal" + suf;
			if (sqlType.Equals("numeric")) return "System.Decimal" + suf;
			if (sqlType.Equals("money")) return "System.Decimal" + suf;
			if (sqlType.Equals("smallmoney")) return "System.Decimal" + suf;
			if (sqlType.Equals("float")) return "float" + suf;
			if (sqlType.Equals("real")) return "double" + suf;
			if (sqlType.Equals("datetime")) return "DateTime" + suf;
			if (sqlType.Equals("smalldatetime")) return "DateTime" + suf;
			if (sqlType.Equals("char")) return "string";
			if (sqlType.Equals("varchar")) return "string";
			if (sqlType.Equals("text")) return "string"; // might be HUGE!
			if (sqlType.Equals("nchar")) return "string";
			if (sqlType.Equals("nvarchar")) return "string";
			if (sqlType.Equals("ntext")) return "string";
			if (sqlType.Equals("binary")) return "byte[]";
			if (sqlType.Equals("varbinary")) return "byte[]";
			if (sqlType.Equals("image")) return "byte[]";
			if (sqlType.Equals("uniqueidentifier")) return "byte[]"; // this MAY be a byte[16] array

			throw new Exception("Unexpected data type: " + Data_Type);
		}

		// generate an Equality condition
		public string GetInEqualityTest()
		{
			if (IsForeignKey())
			{
				// test the IDs of the ActiveRecord objects
				return "(" + GetPrivateVariableName() + " == null) || (value == null) || (value.ID != " + GetPrivateVariableName() + ".ID)";
			}
			else if ((GetNetType().Equals("string")) || (GetNetType().Equals("datetime")))
			{
				// test object equality
				return "(" + GetPrivateVariableName() + " == null) || (value == null) || (!value.Equals(" + GetPrivateVariableName() + "))";
			}
			else
			{
				// test value equality
				return "value != " + GetPrivateVariableName();
			}
		}

		public string GetFieldAttribute()
		{
			if (IsPrimaryKey())
				return "[PrimaryKey(\"" + Column_Name + "\", Access = PropertyAccess.NosetterLowercaseUnderscore)]";
			else if (IsForeignKey())
				return "[BelongsTo(\"" + Column_Name + "\", Type = typeof(" + GetPropertyName() + "), Access = PropertyAccess.NosetterCamelcaseUnderscore)]";
			else
			{
				//FUTURE: if column name is reserved, add a back-tick, like "`User`"
				string prop = "[Property(\"" + Column_Name + "\", Access = PropertyAccess.NosetterCamelcaseUnderscore";
				if (!Is_Nullable) prop = prop + ", NotNull = true";

				if (
					(Data_Type.Equals("text")) ||
					(Data_Type.Equals("ntext"))
					)
				{
					prop += ", ColumnType = \"StringClob\")]";
				}
				else if (GetNetType().Equals("string") && Character_Maximum_Length > 1)
				{
					prop += ", Length = " + Character_Maximum_Length.ToString() + ")";
					prop += ", ValidateLength(1, " + Character_Maximum_Length.ToString() + ")]";
				}
				else
				{
					prop += ")]";
				}
				return prop;
			}
		}

		public override string ToString()
		{
			return _Column_Name +" - "+ _Data_Type;
		}

		#endregion

	}
}
