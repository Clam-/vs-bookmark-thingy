Simple tool to extract (backup) and insert (restore) bookmarks in to a Visual Studio User Options file (.suo)

Help
```
  -s, --suofile=VALUE        Location of .suo file
  -i, --insertfile=VALUE
  -v                         increase debug message verbosity
  -e, --extractfile=VALUE
  -h, --help                 show this message and exit
```

Examples
Restore from saved bookmarks:
```vs-bookmark-thingy -s project/.vs/Project/v16/.suo -i vs.bookmarks```
Backup bookmarks:
```vs-bookmark-thingy -s project/.vs/Project/v16/.suo -e vs.bookmarks```

Only possible due to this cool component: https://github.com/ironfede/openmcdf
(In other words I didn't really do anything but write a little wrapper around that thing.)