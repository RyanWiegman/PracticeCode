from node import *
from linkedList import *
import random

readList = []
newlist = linkedList()

class main :
    for x in range(10) :
        readList.append(random.randint(1, 50))

    print(readList)

    for x in readList :
        addNode = node(x)
        print("Node data before add method: " + str(addNode.data))
        newlist.add(addNode)

    print("Linked list: \n")
    newlist.print()

    

  