using System;
using System.Linq;

namespace Merge_k_Sorted_Lists
{
    class Program
    {
        static void Main(string[] args)
        {
      //ListNode[] lists = new ListNode[5];
      //ListNode l1 = new ListNode(1);
      //l1.next = new ListNode(4);
      //l1.next.next = new ListNode(5);
      //lists[0] = l1;

      //ListNode l2 = new ListNode(1);
      //l2.next = new ListNode(3);
      //l2.next.next = new ListNode(4);
      //lists[1] = l2;

      //ListNode l3 = new ListNode(2);
      //l3.next = new ListNode(6);
      //lists[2] = l3;

      //ListNode l4 = new ListNode(1);
      //l4.next = new ListNode(5);
      //l4.next.next = new ListNode(6);
      //lists[3] = l4;

      //ListNode l5 = new ListNode(3);
      //l5.next = new ListNode(5);
      //lists[4] = l5;

      ListNode[] lists = new ListNode[4];
      lists[0] = null;

      ListNode l1 = new ListNode(-1);
      l1.next = new ListNode(5);
      l1.next.next = new ListNode(11);
      lists[1] = l1;

      lists[2] = null;

      ListNode l2 = new ListNode(6);
      l2.next = new ListNode(3);
      lists[3] = l2;

      Solution s = new Solution();
            var answer = s.MergeKLists(lists);
            while (answer != null)
            {
                Console.WriteLine(answer.val);
                answer = answer.next;
            }
        }
    }



    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public class Solution
    {
    public ListNode MergeKLists(ListNode[] lists)
    {
      ListNode Partition(int start, int end)
      {
        if (start == end) return lists[start];
        while (start < end)
        {
          int mid = start + (end - start) / 2;
          var left = Partition(start, mid);
          var right = Partition(mid + 1, end);
          return Merge(left, right);
        }

        return null;
      }

      ListNode Merge(ListNode l1, ListNode l2)
      {
        var ans = new ListNode();
        var output = ans;
        while (l1 != null && l2 != null)
        {
          if (l1.val < l2.val)
          {
            ans.next = l1;
            l1 = l1.next;
          }
          else
          {
            ans.next = l2;
            l2 = l2.next;
          }
          ans = ans.next;
        }

        ans.next = l1 == null ? l2 : l1;
        return output.next;
      }

      return Partition(0, lists.Length - 1);
    }


    // recursive version of merging
    private ListNode Merge1(ListNode l1, ListNode l2)
        {
            if (l1 == null) return l2;
            if (l2 == null) return l1;
            if (l1.val < l2.val)
            {
                l1.next = Merge1(l1.next, l2);
                return l1;
            }
            else
            {
                l2.next = Merge1(l1, l2.next);
                return l2;
            }
        }
    }
}
