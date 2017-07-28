""
"1st example"

foreach ($objectA in @("a", "e", "i")) {
    "objectA: $objectA"
	foreach ($objectB in @("a", "b", "c", "d", "e")) {
		if ($objectB -eq $objectA) {
			"hit! $objectB"
			break
		} 
		else { 
			"miss! $objectB" 
		}
    }
}

""
"2nd example"

foreach ($objectA in @("a", "e", "i")) {
    foreach ($objectB in @("a", "b", "c", "d", "e")) {
       if ($objectA -eq $objectB) {
		   "hit! $objectB"
		   break;
       }
    }
  }
 
""
"3td example"
 
 :outer foreach ($objectA in @("a", "e", "i")) {
    "objectA: $objectA"
	foreach ($objectB in @("a", "b", "c", "d", "e")) {
		if ($objectB -eq $objectA) {
			"hit! $objectB"
			break outer
		} 
		else { 
			"miss! $objectB" 
		}
    }
}

""
"4th example"

foreach ($objectA in @("a", "e", "i"))
   {
    "objectA: $objectA"
    foreach ($objectB in @("a", "b", "c", "d", "e")) {
       if ($objectB -ne $objectA)
         {
           "miss! $objectB"
           # continue
         }
     else {
           "hit!  $objectB" 
           break
          }
   }
}

""
"5th example"

:loop while ($true)
{
    while ($true)
    {
        break loop
    }
}

""
"end"
