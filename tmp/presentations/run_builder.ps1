$env:RUNTIME_NODE = 'C:\Users\AngeloRicardoFontana\.cache\codex-runtimes\codex-primary-runtime\dependencies\node\bin\node.exe'
$env:RUNTIME_NODE_MODULES = 'C:\Users\AngeloRicardoFontana\.cache\codex-runtimes\codex-primary-runtime\dependencies\node\node_modules'
$env:RUNTIME_BIN_DIR = 'C:\Users\AngeloRicardoFontana\.cache\codex-runtimes\codex-primary-runtime\dependencies\bin\override'

& $env:RUNTIME_NODE "$PSScriptRoot\build_legacy_support_deck.mjs"
exit $LASTEXITCODE
