using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ActiveRecordGenerator.CodeGen
{
	public class DbTableInfo
	{
		//TODO: Create a hashmap of plural words and their singular equivalent
		/*
SingularToPlural = {
    "search"      => "searches",
    "switch"      => "switches",
    "fix"         => "fixes",
    "box"         => "boxes",
    "process"     => "processes",
    "address"     => "addresses",
    "case"        => "cases",
    "stack"       => "stacks",
    "wish"        => "wishes",
    "fish"        => "fish",

    "category"    => "categories",
    "query"       => "queries",
    "ability"     => "abilities",
    "agency"      => "agencies",
    "movie"       => "movies",

    "archive"     => "archives",

    "index"       => "indices",

    "wife"        => "wives",
    "safe"        => "saves",
    "half"        => "halves",

    "move"        => "moves",

    "salesperson" => "salespeople",
    "person"      => "people",

    "spokesman"   => "spokesmen",
    "man"         => "men",
    "woman"       => "women",

    "basis"       => "bases",
    "diagnosis"   => "diagnoses",

    "datum"       => "data",
    "medium"      => "media",
    "analysis"    => "analyses",

    "node_child"  => "node_children",
    "child"       => "children",

    "experience"  => "experiences",
    "day"         => "days",

    "comment"     => "comments",
    "foobar"      => "foobars",
    "newsletter"  => "newsletters",

    "old_news"    => "old_news",
    "news"        => "news",

    "series"      => "series",
    "species"     => "species",

    "quiz"        => "quizzes",

    "perspective" => "perspectives",

    "ox"          => "oxen",
    "photo"       => "photos",
    "buffalo"     => "buffaloes",
    "tomato"      => "tomatoes",
    "dwarf"       => "dwarves",
    "elf"         => "elves",
    "information" => "information",
    "equipment"   => "equipment",
    "bus"         => "buses",
    "status"      => "statuses",
    "status_code" => "status_codes",
    "mouse"       => "mice",

    "louse"       => "lice",
    "house"       => "houses",
    "octopus"     => "octopi",
    "virus"       => "viri",
    "alias"       => "aliases",
    "portfolio"   => "portfolios",

    "vertex"      => "vertices",
    "matrix"      => "matrices",

    "axis"        => "axes",
    "testis"      => "testes",
    "crisis"      => "crises",

    "rice"        => "rice",
    "shoe"        => "shoes",

    "horse"       => "horses",
    "prize"       => "prizes",
    "edge"        => "edges"
		 */

		private string _TableName;
		private DbFieldInfo[] _DbFieldInfo;

		public DbTableInfo(string p_TableName)
		{
			_TableName = p_TableName;
		}

		// Find the LastWord in a mixed case string, based on upper case characters
		public static string LastWord(string mixedCaseName)
		{
			string lastWord = mixedCaseName;
			char[] nameChars = mixedCaseName.ToCharArray();
			bool found = false;
			for (int i = nameChars.Length - 1; i >= 0; i--)
			{
				found = Char.IsUpper(nameChars[i]);
				if (found)
				{
					lastWord = mixedCaseName.Substring(i);
					break;
				}
			}
			return lastWord;
		}

		public DbFieldInfo[] GetFields()
		{
			return _DbFieldInfo;
		}

		/// <summary>
		/// GetFieldList - gather an array of all fields in this table or view
		/// </summary>
		/// <param name="p_Conn">an open database connection</param>
		/// <returns></returns>
		internal void CollectFields(IDbConnection p_Conn)
		{
			string sqlQuery =
					"SELECT c.Column_Name, c.Column_Default, c.Is_Nullable, "
				+ " c.Data_Type, c.Character_Maximum_Length, "
				+ " c.Numeric_Precision, c.Numeric_Scale "
				+ " FROM Information_Schema.Columns c "
				+ " WHERE Table_Name = @Table "
				+ " ORDER BY Ordinal_Position ; ";

			List<DbFieldInfo> list = new List<DbFieldInfo>();
			DbFieldInfo dbFieldInfo = null;
			int i;

			// Connect to database, collect list of tables 
			IDbCommand cmd = null;
			IDataReader reader = null;

			string Column_Name;
			string Column_Default;
			string Is_Nullable;
			bool bIs_Nullable;
			int Character_Maximum_Length;
			int Numeric_Precision;
			int Numeric_Scale;
			string Data_Type;

			try
			{
				cmd = p_Conn.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = sqlQuery;
				IDbDataParameter p = cmd.CreateParameter();
				p.ParameterName = "Table";
				p.Value = _TableName;
				cmd.Parameters.Add(p);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					// Debug.WriteLine("Field: " + reader.GetString(0));

					i = 0;
					Column_Name = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					Column_Default = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					Is_Nullable = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					Data_Type = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					Character_Maximum_Length = reader.IsDBNull(i) ? 0 : reader.GetInt32(i); i++;
					Numeric_Precision = reader.IsDBNull(i) ? (byte)0 : reader.GetByte(i); i++;
					Numeric_Scale = reader.IsDBNull(i) ? 0 : reader.GetInt32(i); i++;

					 bIs_Nullable = Is_Nullable.Equals("YES");
					dbFieldInfo = new DbFieldInfo(Column_Name, Column_Default,
						bIs_Nullable, Character_Maximum_Length, Numeric_Precision, 
						Numeric_Scale, Data_Type);
					list.Add(dbFieldInfo);
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (cmd != null) cmd.Dispose();
			}

			_DbFieldInfo = list.ToArray();
			// identify primary key
			CollectPrimaryKeys(p_Conn);
			// load foreign keys and associate them to dbFieldInfo objects
			CollectForeignKeys(p_Conn);
		}

		/// <summary>
		/// CollectPrimaryKeys - find the primary key column name and set the associated field's flag
		/// </summary>
		/// <param name="p_Conn">an open database connection to the appropriate server and db</param>
		private void CollectPrimaryKeys(IDbConnection p_Conn)
		{
			string sqlQuery = @"SELECT tc.CONSTRAINT_NAME, tc.TABLE_NAME, ccu.COLUMN_NAME"
		+ " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc"
		+ " JOIN INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE ccu ON"
		+ "	ccu.CONSTRAINT_CATALOG = tc.CONSTRAINT_CATALOG"
		+ "	AND ccu.TABLE_NAME = tc.TABLE_NAME"
		+ "	AND ccu.CONSTRAINT_NAME = tc.CONSTRAINT_NAME"
		+ " WHERE tc.CONSTRAINT_TYPE = 'PRIMARY KEY'"
		+ " AND tc.TABLE_NAME = @Table";

			//TODO: Implement CollectPrimaryKeys()
			int i;

			// Connect to database, collect list of tables 
			IDbCommand cmd = null;
			IDataReader reader = null;

			string Constraint_Name;
			string PK_Table;
			string PK_Column;

			try
			{
				cmd = p_Conn.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = sqlQuery;
				IDbDataParameter p = cmd.CreateParameter();
				p.ParameterName = "Table";
				p.Value = _TableName;
				cmd.Parameters.Add(p);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					i = 0;
					Constraint_Name = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					PK_Table = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					PK_Column = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;

					foreach (DbFieldInfo field in _DbFieldInfo)
					{
						if (field.Column_Name.Equals(PK_Column))
						{
							field.Is_Primary_Key = true;
						}
					}
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (cmd != null) cmd.Dispose();
				reader = null;
				cmd = null;
			}
		}		

		private void CollectForeignKeys(IDbConnection p_Conn)
		{
			string sqlQuery = @"SELECT FK.TABLE_NAME AS K_Table,"
		+ " CU.COLUMN_NAME AS FK_Column,"
		+ " PK.TABLE_NAME AS PK_Table,"
		+ " PT.COLUMN_NAME AS PK_Column,"
		+ " C.CONSTRAINT_NAME AS Constraint_Name"
		+ " FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS C"
		+ " INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS FK"
		+ " ON C.CONSTRAINT_NAME = FK.CONSTRAINT_NAME"
		+ " INNER JOIN INFORMATION_SCHEMA.TABLE_CONSTRAINTS PK "
		+ "  ON C.UNIQUE_CONSTRAINT_NAME = PK.CONSTRAINT_NAME"
		+ " INNER JOIN INFORMATION_SCHEMA.KEY_COLUMN_USAGE CU"
		+ "	ON C.CONSTRAINT_NAME = CU.CONSTRAINT_NAME"
		+ " INNER JOIN ("
		+ "		SELECT i1.TABLE_NAME, i2.COLUMN_NAME"
		+ "		FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS i1"
		+ "		INNER JOIN	INFORMATION_SCHEMA.KEY_COLUMN_USAGE i2"
		+ "			ON i1.CONSTRAINT_NAME = i2.CONSTRAINT_NAME"
		+ "		WHERE i1.CONSTRAINT_TYPE = 'PRIMARY KEY'"
		+ "		) PT ON PT.TABLE_NAME = PK.TABLE_NAME"
		+ " WHERE FK.TABLE_NAME = @Table";

			List<DbForeignKeyInfo> list = new List<DbForeignKeyInfo>();
			DbForeignKeyInfo dbForeignKeyInfo = null;
			int i;

			// Connect to database, collect list of tables 
			IDbCommand cmd = null;
			IDataReader reader = null;

			string K_Table;
			string FK_Column;
			string PK_Table;
			string PK_Column;
			string Constraint_Name;

			try
			{
				cmd = p_Conn.CreateCommand();
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = sqlQuery;
				IDbDataParameter p = cmd.CreateParameter();
				p.ParameterName = "Table";
				p.Value = _TableName;
				cmd.Parameters.Add(p);
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					i = 0;
					K_Table = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					FK_Column = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					PK_Table = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					PK_Column = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;
					Constraint_Name = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;

					// Yes, I am ignoring K_Table, and setting a bogus DescriptorColumn
					dbForeignKeyInfo = new DbForeignKeyInfo(FK_Column,
						PK_Table, PK_Column, Constraint_Name, "Name");
					list.Add(dbForeignKeyInfo);
				}
			}
			finally
			{
				if (reader != null) reader.Close();
				if (cmd != null) cmd.Dispose();
				reader = null;
				cmd = null;
			}

			// find a descriptor field (Name, Reason, FileName, etc)
			sqlQuery = "SELECT TOP 1 COLUMN_NAME "
			+" FROM INFORMATION_SCHEMA.COLUMNS"
			+" WHERE DATA_TYPE IN ('nvarchar', 'varchar')"
			+" AND CHARACTER_MAXIMUM_LENGTH > 3"
			+" AND TABLE_NAME = @Table"
			+" ORDER BY CASE WHEN COLUMN_NAME LIKE '%NAME%' THEN 0 ELSE 1 END, ORDINAL_POSITION";
			string PK_DescriptorColumn;

			// assign foreign key info to associated dbFieldInfo
			foreach (DbForeignKeyInfo fk in list)
			{
				// look up descriptor column
				try
				{
					cmd = p_Conn.CreateCommand();
					cmd.CommandType = CommandType.Text;
					cmd.CommandText = sqlQuery;
					IDbDataParameter p = cmd.CreateParameter();
					p.ParameterName = "Table";
					p.Value = fk.PK_Table;
					cmd.Parameters.Add(p);
					reader = cmd.ExecuteReader();
					while (reader.Read())
					{
						i = 0;
						PK_DescriptorColumn = reader.IsDBNull(i) ? "" : reader.GetString(i); i++;

						fk.PK_DescriptorColumn = PK_DescriptorColumn;
					}
				}
				finally
				{
					if (reader != null) reader.Close();
					if (cmd != null) cmd.Dispose();
					reader = null;
					cmd = null;
				}

				foreach (DbFieldInfo fi in _DbFieldInfo)
				{ 
					if (fi.Column_Name.Equals(fk.FK_Column))
					{
						fi.ForeignKeyInfo = fk;
						break;
					}
				}
			}
		}

		/// <summary>
		/// Get Class Name from Table Name
		/// </summary>
		/// This is a simplified version of what Ruby on Rails uses to pluralize classes.
		/// It is enough for me.
		/// <param name="p_TableName"></param>
		/// <returns></returns>
		public string GetClassName()
		{
			string rClass = _TableName;
			int tableLen = _TableName.Length;

			if (_TableName.EndsWith("sses")) { rClass = _TableName.Substring(0, tableLen - 2); }
			else if (_TableName.EndsWith("ches")) { rClass = _TableName.Substring(0, tableLen - 2); }
			else if (_TableName.EndsWith("us")) { /* do nothing */; }
			else if (_TableName.EndsWith("s")) { rClass = _TableName.Substring(0, tableLen - 1); }
			return rClass;
			// return _TableName.EndsWith("s") ? _TableName.Substring(0, _TableName.Length - 1) : _TableName;
		}

		public override string ToString()
		{
			return _TableName;
		}
	}
}
