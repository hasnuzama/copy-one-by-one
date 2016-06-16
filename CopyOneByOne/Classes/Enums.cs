using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CopyOneByOne
{
    public enum MessageType
    {
        Info,
        Warning,
        Error
    }

    public enum KeyValue
    {
        LCtrl = 162,
        RCtrl = 163,
        C = 67,
        V = 86,
        X = 88,
        Q = 81
    }

    public enum Sizes
    {
        ShortcutsWidth = 853,
        ShortcutsHeight = 410,
        RecentCopyWidth = 147,
        RecentCopyHeight = 202,
        RecentCopyLocationX = 725,
        ReccentCopyLocationY = 60,
        ViewShortcutLocationX = 725,
        ViewShortcutLocationY = 268
    }
}
