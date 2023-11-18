using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class MainLevelInfo
{


    private static MainLevelInfo instance;
    public static MainLevelInfo INSTANCE
    {
        get
        {
            if (instance == null)
            {
                instance = new MainLevelInfo();
            }
            return instance;
        }
    }
    private MainLevelInfo() { }

    public int Count { get; set; }
}
