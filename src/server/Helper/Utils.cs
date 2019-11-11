using System;
using System.Collections.Generic;
using BKTMManager.Types;

namespace BKTMManager.Helper {
  public static class Utils {
    public static void LoopListOutput<T>(List<T> items) where T : IGlobalType {
      try {
        foreach (var item in items) {
          Console.WriteLine(item.WhatAmI("normal"));
        }
      } catch(Exception ex) {
        Console.WriteLine(ex);
      }
    }

    public static void LoopPopulatedListOutput<T>(List<T> items) where T : IGlobalType {
      try {
        foreach (var item in items) {
          Console.WriteLine(item.WhatAmI("populate"));
        }
      } catch(Exception ex) {
        Console.WriteLine(ex);
      }
    }

    public static void Output<T>(T item) where T : IGlobalType {
      try {
        Console.WriteLine(item.WhatAmI("normal"));
      } catch(Exception ex) {
        Console.WriteLine(ex);
      }
    }
  }
}
