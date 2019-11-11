using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BKTMManager.Helper {
  class Config {
    public Dictionary<string, string> cnnInfo = new Dictionary<string, string>();

    /*
     * Description : Read config and save to dictionary
     * @param <string> config
     * @return bool
     */
    public bool read(string config) {
      try {
        cnnInfo = File.ReadAllLines(config)
        .Select(l => l.Split(new[] { '=' }))
        .ToDictionary( s => s[0].Trim(), s => s[1].Trim());
        return true;
      } catch (Exception ex) {
        Console.WriteLine("Couldn't Read Config file\n does it exist inside the same folder?", ex);
        return false;
      }
    }

    public Config(string config) {
      this.read(config);
    }
  }
}
