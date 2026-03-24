#!/bin/bash

PS3="Select action: "
options=(
    "Docker compose up"
    "Deploy asp"
    "Deploy wcf"
    "Deploy chat"
    "Quit"
)
select opt in "${options[@]}"
do
    case $REPLY in
        1)
            cd ../docker
            docker compose up -d
            ;;
        2)
            tmux send-keys -t 'asp' 'cd ../docker && docker compose exec sdk bash -c "$SDK_ASP" && docker compose exec runtime bash -c "$RUNTIME_ASP"' C-m
            ;;
        3)
            cd ../docker
            tmux send-keys -t 'wcf' 'cd ../docker && docker compose exec sdk bash -c "$SDK_WCF" && docker compose exec runtime bash -c "$RUNTIME_WCF"' C-m
            ;;
        4)
            cd ../docker
            tmux send-keys -t 'asp' 'cd ../docker && docker compose exec sdk bash -c "$SDK_ASP" && docker compose exec runtime bash -c "$RUNTIME_ASP"' C-m
            tmux send-keys -t 'wcf' 'cd ../docker && docker compose exec sdk bash -c "$SDK_WCF" && docker compose exec runtime bash -c "$RUNTIME_WCF"' C-m
            ;;
        5)
            cd ../docker
            docker compose down
            break
            ;;
        *) echo "invalid option $REPLY";;
    esac
done