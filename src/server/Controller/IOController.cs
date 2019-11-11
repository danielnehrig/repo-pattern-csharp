using System;
using System.Data;
using System.Data.SqlClient;

/*
 * Database Tables
 *
 * Device
 * DeviceReseller
 * Teacher
 * User
 * Hardware
 * Damaged
 * Room
 * Category
 */

namespace BKTMManager.Controller {
  public abstract class IOController {
    protected string _ip;
    protected string _db;
    protected string _user;
    protected string _pw;
    protected SqlConnection _cnn = null;

    public SqlConnection cnn {
      get { return _cnn; }
    }

    // Default Constructor
    public IOController(string ip, string db, string user, string pw) {
      this._ip = ip;
      this._db = db;
      this._user = user;
      this._pw = pw;
      this.initConnection();
    }

    /*
     * open Connection
     * @return bool
     */
    protected bool initConnection() {
      try {
        string connetionString = null;
        connetionString = "Data Source=" + this._ip + ";Initial Catalog=" + this._db + ";User ID=" + this._user + ";Password=" + this._pw;
        this._cnn = new SqlConnection(connetionString);
        Console.WriteLine(connetionString);
        Console.WriteLine("Connection Established!");
        return true;
      }
      catch (Exception ex) {
        Console.WriteLine("Can not open connection!" + ex);
        return false;
      }
    }
  }
}
