#!/bin/bash

if [ $# -eq 1  ]
then
    PROJECT_NAME="day$1"
    dotnet new sln -o $PROJECT_NAME
    cd $PROJECT_NAME

    TESTS="$PROJECT_NAME.Tests"
    dotnet new xunit -lang F# -o $TESTS
    dotnet add $TESTS package FsUnit
    dotnet add $TESTS package FParsec

    dotnet sln add "$TESTS/$TESTS.fsproj"

    dotnet test

    git add .
    git commit -m "setup for the $PROJECT_NAME"
else
    echo "You should give the day of the event :)"
fi