using System;
using System.Data.SqlClient;

namespace BKTMManager.Types {
  public class Student : TypeRepo {
    public Student() { }

    public Student(SqlDataReader reader) {
      this._id = reader.GetInt32(reader.GetOrdinal("st_id"));
      this._firstName = reader.GetString(reader.GetOrdinal("firstName"));
    }

    private int _id;
    public int id {
      get { return _id; }
      set { _id = value; }
    }

    private string _firstName;
    public string firstName {
      get { return _firstName; }
      set { _firstName = value; }
    }
  }
}
