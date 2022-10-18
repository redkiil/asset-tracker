import json
from operator import le
import sys

geodata = json.loads(open(sys.argv[1]).read())
for i in range(len(geodata['features'])):
    geom = geodata['features'][i]['geometry']['coordinates']
    if geom:
        for a in range(len(geom)):
           for b in range(len(geom[a])):
                for c in range(len(geom[a][b])):
                     long = geom[a][b][c][0]
                     lat = geom[a][b][c][1]
                     geodata['features'][i]['geometry']['coordinates'][a][b][c][0] = lat
                     geodata['features'][i]['geometry']['coordinates'][a][b][c][1] = long
print(json.dumps(geodata))

