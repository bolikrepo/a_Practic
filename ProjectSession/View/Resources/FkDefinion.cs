using System;
using DatabaseStore;

namespace ProjectSession
{
    public class FkDefinion
    {
        public DatabaseAdapterPair Source { get; private set; }
        public string TargetColumn { get; private set; }
        public string PreviewOutputColumn { get; private set; }
        public string PreviewDisplayColumn { get; private set; }

        public FkDefinion(string targetColumn, DatabaseAdapterPair srcData, (string, string) displayColumns)
        {
            this.TargetColumn = targetColumn;
            this.Source = srcData;
            this.PreviewOutputColumn = displayColumns.Item1;
            this.PreviewDisplayColumn = displayColumns.Item2;
        }
    }
}
