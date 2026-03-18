#!/bin/bash
session='chat'
tmux new-session -d -s $session

tmux rename-window -t 0 'git'
tmux send-keys -t 'git' 'cd ~/Sources/' C-m

tmux new-window -t $session:1 -n 'docker'
tmux send-keys -t 'docker' 'cd ~/Sources/chat-docker-images/' C-m

tmux new-window -t $session:2 -n 'docker-asp'
tmux send-keys -t 'docker-asp' 'cd ~/Sources/chat-docker-images/' C-m

tmux new-window -t $session:3 -n 'docker-wcf'
tmux send-keys -t 'docker-wcf' 'cd ~/Sources/chat-docker-images/' C-m

tmux new-window -t $session:4 -n 'docker-wcf-bin'
tmux send-keys -t 'docker-wcf-bin' 'cd ~/Sources/chat-docker-images/' C-m

tmux new-window -t $session:5 -n 'docker-asp-bin'
tmux send-keys -t 'docker-asp-bin' 'cd ~/Sources/chat-docker-images/' C-m

tmux attach -t $session:0