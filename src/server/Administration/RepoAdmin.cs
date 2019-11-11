using System;
using System.Data.SqlClient;
using System.Collections.Generic;

/*
 * A Generic Repository to Manage the CRUD pattern among all the Managers(Tables)
 */
namespace BKTMManager.Administration {
  public interface IRepoAdmin<TEntity> where TEntity : class, new() {
    string tableName { get; set; }
    string[] toPopulate { get; set; }
    string columNames { get; set; }
    string prefix { get; set; }
    SqlConnection cnn { get; }

    List<TEntity> GetAll();
    TEntity GetById(int id);
    void Update(int id, string old, string change);
    void Delete(int id);
    void Create(string values);
  }

  public class RepoAdmin<TEntity> : IRepoAdmin<TEntity> where TEntity : class, new() {
    private string[] _toPopulate;
    public string[] toPopulate {
      get { return _toPopulate; }
      set { _toPopulate = value; }
    }

    private string _tableName;
    public string tableName {
      get { return _tableName; }
      set { _tableName = value; }
    }

    private string _prefix;
    public string prefix {
      get { return _prefix; }
      set { _prefix = value; }
    }

    private SqlConnection _cnn;
    public SqlConnection cnn {
      get { return _cnn; }
    }

    private string _columNames;
    public string columNames {
      get { return _columNames; }
      set { _columNames = value; }
    }

    public RepoAdmin(SqlConnection cnn) { 
      _cnn = cnn;
    }

    /*
     * This will get the Column names for use in Create and Update
     */
    public string getColumnsName() {
      List<string> listacolumnas = new List<string>();
      using (SqlCommand command = this._cnn.CreateCommand()) {
        command.CommandText = String.Format("select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '{0}' and t.type = 'U'", this.tableName);
        this._cnn.Open();

        using (var reader = command.ExecuteReader()) {
          while (reader.Read()) {
            listacolumnas.Add(reader.GetString(0));
          }
        }
      }
      string[] result = listacolumnas.ToArray();
      this._cnn.Close();
      return String.Join(", ", result).Substring(4);
    }

    /**
     * Get All Entries from the given Repos Table
     */
    public List<TEntity> GetAll() {
      List<TEntity> entitys = new List<TEntity>();
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("SELECT id AS {1}id,* FROM [dbo].[{0}]", this.tableName, this.prefix);
        SqlDataReader reader = command.ExecuteReader();
        while(reader.Read()) {
          object[] args = new Object[] { reader };
          entitys.Add((TEntity)Activator.CreateInstance(typeof(TEntity), args));
        }
        this._cnn.Close();
      } catch(Exception ex) {
        Console.WriteLine("Error : " + ex);
        return null;
      }
      return entitys;
    }

    /**
     * Get one entry by ID
     */
    public TEntity GetById(int id){
      TEntity entity;
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("SELECT id AS {0}id, * FROM [dbo].[{1}] WHERE id = {2}", this.prefix, this.tableName, id);
        SqlDataReader reader = command.ExecuteReader();
        reader.Read();
        object[] args = new Object[] { reader };
        entity = (TEntity)Activator.CreateInstance(typeof(TEntity), args);
        this._cnn.Close();
      } catch(Exception ex) {
        Console.WriteLine(ex);
        return null;
      }
      return entity;
    }

    /**
     * Delete one entry by ID
     */
    public void Delete(int id) {
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("DELETE FROM [dbo].[{0}] WHERE id = @id", this.tableName);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
        this._cnn.Close();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
    }

    /**
     * Create one entry
     */
    public void Create(string values) {
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("INSERT INTO [dbo].[{0}] ({1}) VALUES ({2})", this.tableName, this.columNames, values);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      this._cnn.Close();
    }

    /**
     * Update one entry by ID
     */
    public void Update(int id, string col, string change) {
      try {
        this._cnn.Open();
        SqlCommand command = this._cnn.CreateCommand();
        command.CommandText = String.Format("UPDATE [dbo].[{0}] SET {1} = {2} WHERE id = @id", this.tableName, col, change);
        command.Parameters.AddWithValue("@id", id);
        command.ExecuteNonQuery();
      } catch (Exception ex) {
        Console.WriteLine(ex);
      }
      this._cnn.Close();
    }
  }
}
