using Mono.Options;
using vs_bookmark_thingy;

var verbosity = 0;
var insertFile = "";
var extractFile = "";
var names = new List<string> ();
var showHelp = false;
var suoFile = "";
// thses are the available options, not that they set the variables
var options = new OptionSet { 
    { "s|suofile=", "Location of .suo file", (string n) => suoFile = n }, 
    { "i|insertfile=", "", (string n) => insertFile = n }, 
    { "v", "increase debug message verbosity", 
        v => { if (v != null) {++verbosity;} } 
    },
    { "e|extractfile=", "", (string n) => extractFile = n }, 
    { "h|help", "show this message and exit", h => showHelp = h != null },
};

void displayHelp(OptionSet opts, string msg="") {
    Console.WriteLine(msg);
    opts.WriteOptionDescriptions(Console.Out);
}

List<string> extra;
try {
    // parse the command line
    extra = options.Parse (args);
} catch (OptionException e) {
    // output some error message
    Console.Write ("ParseError: ");
    Console.WriteLine (e.Message);
    Console.WriteLine ("Try `greet --help' for more information.");
    return;
}
if (showHelp) {
    displayHelp(options);
    return;
}
SUOParser suo;

if (string.IsNullOrEmpty(suoFile)) {
    displayHelp(options, "Need suofile.");
    return;
} else {
    suo = new SUOParser(suoFile);
}

if (!string.IsNullOrEmpty(extractFile)) {
    suo.extract(extractFile);
}
if (!string.IsNullOrEmpty(insertFile)) {
    suo.insert(insertFile);
}