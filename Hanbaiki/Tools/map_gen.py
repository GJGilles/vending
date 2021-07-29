import sys

width = int(sys.argv[1])
height = int(sys.argv[2])
file = open(sys.argv[3], 'a')

def write_slot(f):
    f.write("  - type: 1\n    station: {fileID: 0}\n    recipe: 0\n    item: {fileID: 0}\n    loc: {fileID: 0}\n")

def write_none(f):
    f.write("  - type: 0\n    station: {fileID: 0}\n    recipe: 0\n    item: {fileID: 0}\n    loc: {fileID: 0}\n")


for i in range(width):
    write_none(file)

for i in range(width * (height - 2)):
    if (i % width == 0) or (i % width == width - 1):
        write_none(file)
    else:
        write_slot(file)

for i in range(width):
    write_none(file)