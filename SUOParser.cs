using OpenMcdf;
using System.IO;
namespace vs_bookmark_thingy {
    public class SUOParser {
        private readonly CompoundFile suo;
        public SUOParser(string fname) {
            suo = new CompoundFile(fname, CFSUpdateMode.Update, CFSConfiguration.Default);
        }

        public void extract(string fname) {
            File.WriteAllBytes(fname, suo.RootStorage.GetStream("BookmarkState").GetData());
        }
        public void insert(string fname) {
            Console.WriteLine("Writing data...");
            // byte[] test = { 0x00, 0x00, 0x00, 0x00 };
            // suo.RootStorage.GetStream("BookmarkState").SetData(test);
            suo.RootStorage.GetStream("BookmarkState").SetData(File.ReadAllBytes(fname));
            suo.Commit();
        }
        public void close() {
            suo.Close();
        }
        public void iter(){
            suo.RootStorage.VisitEntries(delegate(CFItem cf) { Console.WriteLine(cf.Name); }, true);
        }
    }
}