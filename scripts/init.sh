#!/bin/bash
session='chat'


export SDK_ASP=$(cat <<END
    cd /source/chat/asp
    dotnet publish -c Release -o /chat/asp 
END
)

export RUNTIME_ASP=$(cat <<END
    cd /app/chat/asp && dotnet chat-asp.dll
END
)


export SDK_WCF=$(cat <<END
    cd /source/chat/wcf
    dotnet publish -c Release -o /chat/wcf
END
)

export RUNTIME_WCF=$(cat <<END
    cd /app/chat/wcf && dotnet chat-wcf.dll
END
)



tmux new-session -d -s $session

tmux rename-window -t 0 'git'
tmux send-keys -t 'git' 'cd ~/Sources/chat/' C-m

tmux new-window -t $session:1 -n 'scripts'
tmux send-keys -t 'scripts' 'cd ~/Sources/chat/scripts && ./menu.sh' C-m

tmux new-window -t $session:2 -n 'asp'
tmux send-keys -t 'asp' 'cd ~/Sources/chat/scripts' C-m

tmux new-window -t $session:3 -n 'wcf'
tmux send-keys -t 'wcf' 'cd ~/Sources/chat/scripts' C-m

tmux attach -t $session:1