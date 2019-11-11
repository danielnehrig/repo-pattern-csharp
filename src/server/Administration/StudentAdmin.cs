using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class StudentAdministration : RepoAdmin<Student> {
    public StudentAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Student";
      prefix = "st_";
      columNames = this.getColumnsName();
    }
  }
}
