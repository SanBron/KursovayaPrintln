using System.Collections.Generic;

namespace KursovayaPrintLn
{
    internal interface WorkMethod
    {
        Model Work(SearchMode searchMode, HashSet<string> searchStrings, System.Windows.Forms.ListBox listBox1);
    }
}
