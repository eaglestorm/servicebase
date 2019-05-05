#!/bin/bash

dotnet build

dotnet test

dotnet run &

cd Tests
gradle test