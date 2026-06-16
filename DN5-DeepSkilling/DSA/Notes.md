# Data Structures & Algorithms (DSA) - Comprehensive Notes

## 📌 Overview

Data Structures are specialized formats for organizing, storing, and accessing data. Algorithms are step-by-step procedures for solving problems. Understanding both is critical for writing efficient software and passing technical interviews.

**Key Point:** Good data structure + good algorithm = efficient solution.

---

## 🎯 Learning Objectives

By the end of this module, you will:
- [ ] Understand Big O notation and complexity analysis
- [ ] Master fundamental data structures
- [ ] Implement essential search and sort algorithms
- [ ] Work with advanced data structures
- [ ] Solve algorithmic problems efficiently
- [ ] Optimize code for performance

---

## 📚 Core Concepts Learned

### 1. **Big O Notation & Complexity Analysis**

**Time Complexity:**
| Notation | Name | Example |
|----------|------|---------|
| O(1) | Constant | Array access |
| O(log n) | Logarithmic | Binary search |
| O(n) | Linear | Simple loop |
| O(n log n) | Linearithmic | Merge sort |
| O(n²) | Quadratic | Nested loops |
| O(2ⁿ) | Exponential | Recursive fibonacci |
| O(n!) | Factorial | Permutations |

**Complexity Rules:**
- Drop constants: O(2n) = O(n)
- Drop non-dominant terms: O(n² + n) = O(n²)
- Different variables: O(a + b), O(a * b)

### 2. **Array & List**

```csharp
// Array
int[] arr = new int[5];
arr[0] = 10;
// Access: O(1), Search: O(n), Insert/Delete: O(n)

// List (Dynamic Array)
List<int> list = new List<int>();
list.Add(10);
list.Insert(0, 5);  // O(n) - shifts elements
list.RemoveAt(0);   // O(n)
// Same complexity as array operations
```

### 3. **Stack & Queue**

```csharp
// Stack (LIFO - Last In First Out)
Stack<int> stack = new Stack<int>();
stack.Push(10);
int top = stack.Pop();
// Push: O(1), Pop: O(1), Peek: O(1)

// Queue (FIFO - First In First Out)
Queue<int> queue = new Queue<int>();
queue.Enqueue(10);
int front = queue.Dequeue();
// Enqueue: O(1), Dequeue: O(1), Peek: O(1)
```

### 4. **Linked List**

```csharp
public class LinkedListNode<T>
{
    public T Data { get; set; }
    public LinkedListNode<T> Next { get; set; }
}

public class MyLinkedList<T>
{
    private LinkedListNode<T> head;
    
    public void Insert(T data) // O(n)
    {
        var newNode = new LinkedListNode<T> { Data = data };
        newNode.Next = head;
        head = newNode;
    }
    
    public void Delete(T data) // O(n)
    {
        if (head?.Data.Equals(data) == true)
        {
            head = head.Next;
            return;
        }
        
        var current = head;
        while (current?.Next != null)
        {
            if (current.Next.Data.Equals(data))
            {
                current.Next = current.Next.Next;
                return;
            }
            current = current.Next;
        }
    }
}
// Access: O(n), Search: O(n), Insert: O(1), Delete: O(1)
```

### 5. **Hash Table / Dictionary**

```csharp
Dictionary<string, int> map = new Dictionary<string, int>();
map["apple"] = 5;
int count = map["apple"];
map.Remove("apple");
// Access: O(1), Insert: O(1), Delete: O(1)
```

### 6. **Tree & Binary Search Tree**

```csharp
public class TreeNode
{
    public int Value { get; set; }
    public TreeNode Left { get; set; }
    public TreeNode Right { get; set; }
}

public class BinarySearchTree
{
    private TreeNode root;
    
    public void Insert(int value) // O(log n) average, O(n) worst
    {
        root = InsertRecursive(root, value);
    }
    
    private TreeNode InsertRecursive(TreeNode node, int value)
    {
        if (node == null)
            return new TreeNode { Value = value };
        
        if (value < node.Value)
            node.Left = InsertRecursive(node.Left, value);
        else if (value > node.Value)
            node.Right = InsertRecursive(node.Right, value);
        
        return node;
    }
    
    public bool Search(int value) // O(log n) average
    {
        return SearchRecursive(root, value);
    }
    
    private bool SearchRecursive(TreeNode node, int value)
    {
        if (node == null)
            return false;
        
        if (value == node.Value)
            return true;
        if (value < node.Value)
            return SearchRecursive(node.Left, value);
        return SearchRecursive(node.Right, value);
    }
}
```

### 7. **Graph**

```csharp
public class Graph
{
    private Dictionary<int, List<int>> adjList;
    
    public Graph(int vertices)
    {
        adjList = new Dictionary<int, List<int>>();
    }
    
    public void AddEdge(int u, int v) // O(1)
    {
        if (!adjList.ContainsKey(u))
            adjList[u] = new List<int>();
        adjList[u].Add(v);
    }
    
    // Depth-First Search: O(V + E)
    public void DFS(int start)
    {
        var visited = new HashSet<int>();
        DFSHelper(start, visited);
    }
    
    private void DFSHelper(int vertex, HashSet<int> visited)
    {
        visited.Add(vertex);
        Console.WriteLine(vertex);
        
        foreach (var neighbor in adjList[vertex])
        {
            if (!visited.Contains(neighbor))
                DFSHelper(neighbor, visited);
        }
    }
    
    // Breadth-First Search: O(V + E)
    public void BFS(int start)
    {
        var visited = new HashSet<int> { start };
        var queue = new Queue<int>();
        queue.Enqueue(start);
        
        while (queue.Count > 0)
        {
            int vertex = queue.Dequeue();
            Console.WriteLine(vertex);
            
            foreach (var neighbor in adjList[vertex])
            {
                if (!visited.Contains(neighbor))
                {
                    visited.Add(neighbor);
                    queue.Enqueue(neighbor);
                }
            }
        }
    }
}
```

### 8. **Sorting Algorithms**

```csharp
// Bubble Sort: O(n²)
public void BubbleSort(int[] arr)
{
    int n = arr.Length;
    for (int i = 0; i < n - 1; i++)
    {
        for (int j = 0; j < n - i - 1; j++)
        {
            if (arr[j] > arr[j + 1])
            {
                int temp = arr[j];
                arr[j] = arr[j + 1];
                arr[j + 1] = temp;
            }
        }
    }
}

// Quick Sort: O(n log n) average
public void QuickSort(int[] arr, int low, int high)
{
    if (low < high)
    {
        int pi = Partition(arr, low, high);
        QuickSort(arr, low, pi - 1);
        QuickSort(arr, pi + 1, high);
    }
}

private int Partition(int[] arr, int low, int high)
{
    int pivot = arr[high];
    int i = low - 1;
    
    for (int j = low; j < high; j++)
    {
        if (arr[j] < pivot)
        {
            i++;
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
    
    int temp2 = arr[i + 1];
    arr[i + 1] = arr[high];
    arr[high] = temp2;
    return i + 1;
}

// Merge Sort: O(n log n)
public void MergeSort(int[] arr, int left, int right)
{
    if (left < right)
    {
        int mid = left + (right - left) / 2;
        MergeSort(arr, left, mid);
        MergeSort(arr, mid + 1, right);
        Merge(arr, left, mid, right);
    }
}

private void Merge(int[] arr, int left, int mid, int right)
{
    int[] temp = new int[right - left + 1];
    int i = left, j = mid + 1, k = 0;
    
    while (i <= mid && j <= right)
    {
        if (arr[i] <= arr[j])
            temp[k++] = arr[i++];
        else
            temp[k++] = arr[j++];
    }
    
    while (i <= mid)
        temp[k++] = arr[i++];
    
    while (j <= right)
        temp[k++] = arr[j++];
    
    for (i = left; i <= right; i++)
        arr[i] = temp[i - left];
}
```

### 9. **Searching Algorithms**

```csharp
// Linear Search: O(n)
public int LinearSearch(int[] arr, int target)
{
    for (int i = 0; i < arr.Length; i++)
        if (arr[i] == target)
            return i;
    return -1;
}

// Binary Search: O(log n)
public int BinarySearch(int[] arr, int target)
{
    int left = 0, right = arr.Length - 1;
    
    while (left <= right)
    {
        int mid = left + (right - left) / 2;
        
        if (arr[mid] == target)
            return mid;
        else if (arr[mid] < target)
            left = mid + 1;
        else
            right = mid - 1;
    }
    
    return -1;
}
```

---

## 💻 Hands-On Exercises

### Exercise 1: Array Operations
**Task:** Implement operations like reverse, rotate, and find duplicates

### Exercise 2: Stack & Queue
**Task:** Solve problems like balanced parentheses, implement deque

### Exercise 3: Linked Lists
**Task:** Reverse a linked list, detect cycles, merge lists

### Exercise 4: Trees
**Task:** Implement tree traversals, find LCA, validate BST

### Exercise 5: Sorting & Searching
**Task:** Implement all major sorting and searching algorithms

---

## 📝 Assignments

1. **Expression Evaluator**
   - Use stack for postfix notation evaluation
   - Handle operator precedence

2. **Tree Problems**
   - Find common ancestor
   - Path sum problems
   - Tree serialization

3. **Graph Problems**
   - Shortest path (BFS/Dijkstra)
   - Topological sorting
   - Connected components

---

## 🔗 References

### Online Judges:
- [LeetCode](https://leetcode.com/)
- [HackerRank](https://www.hackerrank.com/)
- [Codewars](https://www.codewars.com/)

### Books:
- Introduction to Algorithms (CLRS)
- Algorithms, 4th Edition by Sedgewick & Wayne

### Resources:
- [Big O Cheat Sheet](https://www.bigocheatsheet.com/)
- [VisuAlgo - Visualizing Algorithms](https://visualgo.net/)

---

## 📋 Personal Notes

**Date Started:** _______________
**Topics Mastered:**
- [ ] Complexity Analysis
- [ ] Arrays & Lists
- [ ] Stacks & Queues
- [ ] Trees
- [ ] Graphs
- [ ] Sorting
- [ ] Searching

**Challenges Faced:**
_________________________________
_________________________________

**Key Takeaways:**
_________________________________
_________________________________

**Problems Solved:** ______

---

**Last Updated:** June 2026
**Completion Status:** Not Started
