using System;
using System.Collections.Generic;
using BKTMManager.Helper;
using BKTMManager.Administration;
using BKTMManager.Controller;

namespace BKTMManager.Administration {
  public class Manager : IOController {
    public TeacherAdministration teacher;
    public StudentAdministration student;

    public Manager(Dictionary<string, string> cnnInfo):base(cnnInfo["ip"], cnnInfo["db"], cnnInfo["user"], cnnInfo["pw"]) {
      teacher = new TeacherAdministration(this._cnn);
      student = new StudentAdministration(this._cnn);
    }
  }
}
