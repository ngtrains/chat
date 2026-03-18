# Getting Started
- [Install git](https://git-scm.com/) with git bash. 
- Install [msys2](https://www.msys2.org/). Follow instructions on that page and be sure to close window when it tells you to and reopen to complete setup.

# Install TMUX
- In a msys2 window, use Pacman to install tmux (`pacman -S tmux`).
- Copy `tmux` binary and `msys-event-*` DLLs from msys2 bin folder (probably `C:\msys64\usr\bin`) to git bash bin folder (probably `C:\Program Files\Git\usr\bin`).
- Restart your git bash and try `tmux` command.

# Commands
`tmux new`\
`C-b :` - Open interactive command prompt.\
`C-b d` - Detach from TMUX.\
`tmux attach`

## Creating windows
`C-b c` - Create a new window with default name\
`C-b ,` - Rename the current window\
`C-b &` - Kill the current window (with confirmation)


## Navigation between windows
`C-b w` - Choose window from a list\
`C-b f` - Find window by name
