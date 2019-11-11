using System;
using System.Collections.Generic;
using BKTMManager.Administration;
using BKTMManager.Helper;
using BKTMManager.Types;

namespace BKTMManager.ConsoleApp {
  public static class ConsoleApplication {
    public static int Start() {
      try {
        // Read the Config which holds Database connection information
        Config config = new Config("config.cfg");
        Dictionary<string, string> cnnInfo = config.cnnInfo;

        // Load Administration manager v2 with repo design pattern
        Manager manager = new Manager(cnnInfo);

        Console.Clear();
      } catch (Exception ex) {
        Console.WriteLine(ex);
        return 1;
      }
      return 0;
    }
  }
}
