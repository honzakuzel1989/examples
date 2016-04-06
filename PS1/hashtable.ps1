#http://ss64.com/ps/syntax-hash-tables.html
#https://technet.microsoft.com/en-us/library/ee692803.aspx

# (!!) hashtable in ps = associative heterogeneous data structure
# the built-in properties of a hash table include .Keys .Values and .Count
#
# init: 
# $h = ${} #empty
# $h = ${1='1'; 2='2'}
# get:
# $h[1] #'1'
# $h.Get_Item(1) #'1'
# set:
# $h.Set_Item(1, "one") #$h[1] == "one"
# count:
# $h.count #2
# remove:
# $h.Remove(2)
# contains:
# $h.containsKey(1) #True
# $h.containsValue(1) #False
# keys:
# $h.keys #1
# values:
# $h.Values #one
# combine:
# $i = @{2 = "two"}
# $i = $i + $h

function Print($p)
{
  if($p) { echo $p }
  else { echo "empty"}
}

# empty hash table
$ht = @{}
Print $ht

# initialization of hash table
$nums = @{1 = "one"; 2 = "two"; 3 = "three"}
Print $nums

# different type of keys
$nums_dk = @{1 = "one"; '2' = "two"; "3" = "three"}
Print $nums_dk

# different type of keys and values
$nums_dkav = @{1 = "one"; '2' = 2; "3" = 3}
Print $nums_dkav

# get value by not exist key produces empty output
Print $ht[0]
Print $ht["nonexist"]
Print $ht['c']

# get value (using index)
Print ">Index []"
Print $nums[2]
# wrong types -> empty
Print $nums['2']
Print $nums[2.0]
# explicit conversion
Print $nums[[int]2.0]
# not exist key -> empty
Print $nums[5]

Print $nums_dkav[1]
Print $nums_dkav["3"]
Print $nums_dkav[[string]3]
Print $nums_dkav[3]

# get value (using Get_Item) - same output like indexer
Print ">Get_Item"
Print $nums_dkav.Get_Item(1)
# (!) Convert '1' to 1
Print $nums_dkav.Get_Item([int]'1')
Print $nums_dkav.Get_Item("3")
Print $nums_dkav.Get_Item([string]3)
Print $nums_dkav.Get_Item(3)

# set item (using indexer)
Print ">Index []"
$ht["pi"] = 3.1
Print $ht
# (!) add new keyvaluepair to hashtable with same key
$ht["pi"] = 3.14
Print $ht
Print $ht["pi"]

# set item (using Set_Item)
Print ">Set_Item"
# (!) change or add keyvaluepair to hashtable -> use Set_Item
$ht.Set_Item("pi", "3.141592653589793")
$ht.Set_Item("e", "2,71828")
Print $ht
Print $ht["pi"]
$ht.Set_Item("pi", 3.1415)
Print $ht
Print $ht["pi"]
Print $ht["e"]

#add item using assignment
Print ">assignment"
$h.X = 'x'
$h
$h.X

# delete item and count method
Print ">remove"
$ht.count
$ht.Remove("pi")
$ht.count
$ht.Remove("e")
$ht.count
# IsEmpty test
Print ($ht.count -eq 0)

# loop - keyvaluepair
Print ">loop"
# (!) GetEnumerator required
foreach($x in $nums_dkav.GetEnumerator())
{
  "[" + $x.Key + "] = " + $x.Value
}
# in general, GetEnumerator method effectively sends each entry in the hash table across 
# the pipeline as a separate object - for example for sort
$nums_dkav.GetEnumerator() | sort Name

#$nums_dkav | sort not working (!)

# obtain keys collection
Print ">keys"
$nums_dkav.keys | foreach {"k=" + $_}

# obtain values collection
Print ">values"
foreach($v in $nums_dkav.values) { "v=" + $v}

# combine
Print "combine>"
$ht.Set_Item(4, "4")
$tmp = $ht + $nums_dk
$tmp
$ht.Set_Item("3", 3)
# (!) Error - $ht contains same key like $nums_dk
Try { $tmp = $ht + $nums_dk }
Catch { "! Error" }
$tmp

# SPLAT operator
# (!) in PowerShell 2.0 is the ability to expand a hash table into a set of command line parameters using SPLAT @ operator
Print ">SPLAT"
$params = @{Path = "C:\"; Recurse = $false; "Filter" = "Windows"}
ls @params