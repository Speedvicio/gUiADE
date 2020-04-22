Usage: uade123 [<options>] <input file> ...

OPTIONS:

 -1, --one,          Play at most one subsong per file
 -@ filename, --list=filename,  Read playlist of files from 'filename'
 --ao-option=x:y,    Set option for libao, where 'x' is an audio driver specific
                     option and 'y' is a value. Note 'x' may not contain
                     ':' character, but 'y' may. This option can be used
                     multiple times to specify multiple options.
                     Example for alsa09 plugin: --ao-option=dev:default
 --buffer-time=x,    Set audio buffer length to x milliseconds. The default
                     value is determined by the libao.
 -c, --stdout        Write sample data to stdout
 --cygwin,           Cygwin path name workaround: X:\ -> /cygdrive/X
 --detect-format-by-content, Detect modules strictly by file content.
                     Detection will ignore file name prefixes.
 --disable-timeouts, Disable timeouts. This can be used for songs that are
                     known to end. Useful for recording fixed time pieces.
                     Some formats, such as protracker, disable timeouts
                     automatically, because it is known they will always end.
 -e format,          Set output file format. Use with -f. wav is the default
                     format.
 --enable-timeouts,  Enable timeouts. See --disable-timeouts.
 -f filename,        Write audio output into 'filename' (see -e also)
 --filter=model      Set filter model to A500, A1200 or NONE. The default is
                     A500. NONE means disabling the filter.
 --filter,           Enable filter emulation. It is enabled by default.
 --force-led=0/1,    Force LED state to 0 or 1. That is, filter is OFF or ON.
 --frequency=x,      Set output frequency to x Hz. The default is 44,1 kHz.
 -G x, --gain=x,     Set volume gain to x in range [0, 128]. Default is 1,0.
 -g, --get-info,     Just print playername and subsong info on stdout.
                     Do not play.
 -h, --help,         Print help
 --headphones,       Enable headphones postprocessing effect.
 --headphones2       Enable headphones 2 postprocessing effect.
 -i, --ignore,       Ignore eagleplayer fileformat check result. Play always.
 -j x, --jump=x,     Jump to time position 'x' seconds from the beginning.
                     fractions of a second are allowed too.
 -k 0/1, --keys=0/1, Turn action keys on (1) or off (0) for playback control
                     on terminal.
 -n, --no-ep-end-detect, Ignore song end reported by the eagleplayer. Just
                     keep playing. This does not affect timeouts. Check -w.
 --ntsc,             Set NTSC mode for playing (can be buggy).
 --pal,              Set PAL mode (default)
 --normalise,        Enable normalise postprocessing effect.
 -p x, --panning=x,  Set panning value in range [0, 2]. 0 is full stereo,
                     1 is mono, and 2 is inverse stereo. The default is 0,7.
 -P filename,        Set player name
 -r, --recursive,    Recursive directory scan
 --repeat,           Play playlist over and over again
 --resampler=x       Set resampling method to x, where x = default, sinc
                     or none.
 -s x, --subsong=x,  Set subsong 'x'
 --scan              Scan given files and directories for playable songs and
                     print their names, one per line on stdout.
                     Example: uade123 --scan /song/directory
 --set="options"     Set song.conf options for each given song.
 --speed-hack,       Set speed hack on. This gives more virtual CPU power.
 --stderr,           Print messages on stderr rather than stdout
 -t x, --timeout=x,  Set song timeout in seconds. -1 is infinite.
                     The default is infinite.
 -v,  --verbose,     Turn on verbose mode
 -w x, --subsong-timeout=x,  Set subsong timeout in seconds. -1 is infinite.
                             Default is 512s
 -x y, --ep-option=y, Use eagleplayer option y. Option can be used many times.
                      Example: uade123 -x type:nt10 mod.foobar, will play
                      mod.foobar as a Noisetracker 1.0 module. See eagleplayer
                      options from the man page.
 -y x, --silence-timeout=x,  Set silence timeout in seconds. -1 is infinite.
                         Default is 20s
 -z, --shuffle,      Randomize playlist order before playing.

EXPERT OPTIONS:

 --basedir=dirname,  Set uade base directory (contains data files)
 -d, --debug,        Enable debug mode (expert only)
 -S filename,        Set sound core name
 --scope,            Turn on Paula hardware register debug mode
 -u uadename,        Set uadecore executable name

ACTION KEYS FOR INTERACTIVE MODE:
 [0-9]         Change subsong.
 '<'           Previous song.
 '.'           Skip 10 seconds forward.
 SPACE, 'b'    Next subsong.
 'c'           Pause.
 'f'           Toggle filter (takes filter control away from eagleplayer).
 'g'           Toggle gain effect.
 'h'           Print this list.
 'H'           Toggle headphones effect.
 'i'           Print module info.
 'I'           Print hex dump of head of module.
 'N'           Toggle normalise effect.
 RETURN, 'n'   Next song.
 'p'           Toggle postprocessing effects.
 'P'           Toggle panning effect. Default value is 0.7.
 'q'           Quit.
 's'           Toggle between random and normal play.
 'v'           Toggle verbose mode.
 'x'           Restart current subsong.
 'z'           Previous subsong.

Example: Play all songs under /chip/fc directory in shuffling mode:
  uade -z /chip/fc/*