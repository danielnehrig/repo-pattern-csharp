namespace BKTMManager.Types {
  public class TypeRepo : IGlobalType {
    public string tablePopulated;
    public string tableNormal;

    public string WhatAmI(string mode) {
      switch(mode) {
        case "populate":
          return this.tablePopulated;
        default:
          return this.tableNormal;
      }
    }
  }
}
