# Arguments

When we run a host and want to provide arguments it is expected to follow the more verbose "key=value" format.

Items that are only key will be ignored.

Examples:

Good examples:

`dotnet run -- settings=mysettings.json`
`dotnet run -- settings=mysettings.json start=runtime235 logging=false`

Examples that won't work:

The following will result in `logging` not parsed as a recognised command-line arguments.

`dotnet run -- logging`

The following example will parse `logging` to have the value of `false=debug`

`dotnet run -- settings=mysettings.json start=runtime235 logging=false=debug`

The following example will also not recognise `logging` as a valid argument as it has no values.

`dotnet run -- settings=mysettings.json start=runtime235 logging=`
