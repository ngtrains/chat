#!/bin/bash
session='chat'
tmux new-session -d -s $session

tmux rename-window -t 0 'git'
tmux send-keys -t 'git' 'cd ~/Sources/chat/' C-m

tmux new-window -t $session:1 -n 'docker'
tmux send-keys -t 'docker' 'cd ~/Sources/chat/docker/' C-m

tmux attach -t $session:0

