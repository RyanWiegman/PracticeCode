

class linkedList : 
    def __init__(self) : 
        self.head = None
        
     
     
    def print(self) :
        temp = self.head
        #print("inside print:" + str(self.head.next.data))

        while(temp is not None) :
            print("inside print")
            print(temp.data)
            temp = temp.next

    def add(self, tempNode) :
        tempheader = self.head
        if self.head is None
            self.head = tempNode
            print("head data: " + str(self.head.data))
        else :
            while self.head is not None : 
                print("current node data: " + str(self.head.data))
                self.head = self.head.next
            
            self.head = tempNode


