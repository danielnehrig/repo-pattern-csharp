using System;
using System.Data.SqlClient;
using BKTMManager.Administration;
using BKTMManager.Types;

namespace BKTMManager.Administration {
  public class TeacherAdministration : RepoAdmin<Teacher> {
    public TeacherAdministration(SqlConnection cnn):base(cnn) { 
      tableName = "Teacher";
      prefix = "te_";
      columNames = this.getColumnsName();
    }
  }
}
