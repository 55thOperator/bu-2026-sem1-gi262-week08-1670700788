# Assignment 08: การเรียนรู้ Recursive Algorithms สำหรับ Game Development

## 🎯 จุดประสงค์การเรียนรู้

- เรียนรู้การใช้งาน Recursive Algorithms พื้นฐาน (Factorial, Fibonacci, Power, GCD, Binary Search)
- เข้าใจหลักการของ Recursion รวมถึง Base Case และ Recursive Case
- นำ Recursive Algorithms มาใช้ในการแก้ปัญหาในเกม เช่น การคำนวณคอมบิเนชัน, ลำดับ Fibonacci สำหรับ AI, การตรวจสอบ Palindrome
- วิเคราะห์ประสิทธิภาพและข้อจำกัดของ Recursion
- เขียน code ที่มีประสิทธิภาพในการจัดการปัญหาที่ซับซ้อนด้วย Recursion

## 📚 โครงสร้างของ Assignment

- **Lecture Methods (4 methods)** - การ implement ฝึกหัด Recursive Algorithms พื้นฐาน พร้อมกันในห้องเรียน
- **Assignment Methods (4 methods)** - การประยุกต์ใช้ Recursive Algorithms ในสถานการณ์เกม

## ไฟล์ที่ใช้และวิธีทำงาน

- เขียนคำตอบใน `StudentSolution.cs` ภายใน namespace `Assignment` และ class `StudentSolution`
- Test Cases ใน `Assignment_Testcase.cs` สร้าง object ด้วย `new StudentSolution()` และเรียก public methods โดยตรง จึงไม่ต้องใช้ interface
- คงชื่อ method, ชนิดค่าที่คืน, parameters และระดับการเข้าถึง `public` ของทั้ง 8 methods ตามที่กำหนด เพื่อให้ Test Cases เรียกใช้งานได้
- เติมคำตอบใน private helper methods ที่เตรียมไว้ โดยใช้ Recursion และกำหนด Base Case ก่อน Recursive Case
- ค่า `return -1;` และ `return false;` ใน helper methods เป็นค่าชั่วคราวที่ต้องแทนด้วยคำตอบ ไม่ใช่ผลลัพธ์ที่ถูกต้องสำหรับทุก input
- ตรวจสอบผ่าน Unity Test Runner (หมวด `Lecture` และ `Assignment`) โดยไม่แก้ Test Cases เพื่อให้ผ่าน

Test Cases ตรวจสอบผลลัพธ์ของ input ที่กำหนด แต่ไม่ได้ตรวจสอบว่าใช้ Recursion จริงหรือไม่ จึงต้องตรวจสอบโค้ดให้ตรงกับวัตถุประสงค์ของโจทย์ด้วย

---

## การคืนค่าและการตรวจสอบ Test Cases

ทุก method ต้องคืนค่าผลลัพธ์ผ่าน `return` โดย Test Cases ตรวจสอบค่าที่คืนมาโดยตรง ไม่ใช้ข้อความจาก `Debug.Log` หรือ `AssignmentDebugConsole` ในการตัดสินผล

- Methods ที่คำนวณตัวเลขและ Binary Search คืนค่า `int`
- `ASN02_IsPalindrome` คืนค่า `bool` (`true` หรือ `false`)
- Test Cases ใช้ `Assert.That(actual, Is.EqualTo(expected))` สำหรับ `int` และ `bool`

ตัวอย่างการตรวจสอบค่าที่คืนมา:
```csharp
// ตัวอย่างภายใน NUnit test ที่มี using NUnit.Framework; และ using Assignment;
StudentSolution assignment = new StudentSolution();
int actual = assignment.LCT01_RecursiveFactorial(5);
Assert.That(actual, Is.EqualTo(120));

bool isPalindrome = assignment.ASN02_IsPalindrome("radar");
Assert.That(isPalindrome, Is.EqualTo(true));
```

## 🧠 ความรู้พื้นฐานที่ควรทราบ

### Recursion คืออะไร?
Recursion คือเทคนิคการเขียนฟังก์ชันที่เรียกตัวเองซ้ำเพื่อแก้ปัญหา โดยแบ่งปัญหาใหญ่เป็นปัญหาย่อยๆ จนถึง Base Case ที่หยุดการเรียกซ้ำ

### ส่วนประกอบของ Recursion
- **Base Case**: เงื่อนไขที่หยุดการเรียกซ้ำ
- **Recursive Case**: การเรียกฟังก์ชันตัวเองด้วย input ที่เล็กลง

### ใช้ Recursion ทำอะไรบ้าง?
- **คำนวณคอมบิเนชัน**: Factorial สำหรับจำนวนวิธีการจัดเรียง
- **สร้างลำดับ**: Fibonacci สำหรับการเคลื่อนไหวหรือการเติบโต
- **ค้นหา**: Binary Search ในข้อมูลที่เรียงลำดับ
- **ตรวจสอบ**: Palindrome สำหรับการตรวจสอบคำหรือรหัส

---

## Lecture Methods

### 1. LCT01_RecursiveFactorial

**วัตถุประสงค์:** เรียนรู้การคำนวณ Factorial ด้วย Recursion

**คำอธิบายปัญหา:**
Factorial (n!) คือผลคูณของจำนวนเต็มบวกตั้งแต่ 1 ถึง n เช่น 5! = 5 × 4 × 3 × 2 × 1 = 120

ในเกม Factorial มักใช้ในการคำนวณ:
- จำนวนวิธีการจัดเรียงไอเท็ม (Permutation)
- คำนวณความน่าจะเป็นหรือคอมบิเนชันต่างๆ
- สร้างระบบ progression ที่เพิ่มขึ้นแบบทวีคูณ

**หลักการทำงานของ Factorial:**
- n! = n * (n-1) * (n-2) * ... * 1
- Base Case: 
    + 0! หรือ factorial(0) = 1 
    + 1! หรือ factorial(1) = 1
- Recursive Case: n! = n * (n-1)!

**Method Signature:**
```csharp
public int LCT01_RecursiveFactorial(int n)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameter n
2. ตรวจสอบ Base Case: ถ้า n <= 1 ให้ return 1
3. Recursive Case: return n * Factorial(n-1)
4. คืนค่าผลลัพธ์เป็น int

**Test Cases:**
1. **Input:** n = 5
   **Expected Return Value:**
   ```
   120
   ```

2. **Input:** n = 0
   **Expected Return Value:**
   ```
   1
   ```

3. **Input:** n = 1
   **Expected Return Value:**
   ```
   1
   ```

4. **Input:** n = 3
   **Expected Return Value:**
   ```
   6
   ```

5. **Input:** n = 4
   **Expected Return Value:**
   ```
   24
   ```

6. **Input:** n = 6
   **Expected Return Value:**
   ```
   720
   ```

### 2. LCT02_RecursiveFibonacci

**วัตถุประสงค์:** เรียนรู้การคำนวณ Fibonacci Sequence ด้วย Recursion

**คำอธิบายปัญหา:**
Fibonacci Sequence เป็นลำดับตัวเลขที่แต่ละตัวเป็นผลรวมของสองตัวก่อนหน้า เช่น 0, 1, 1, 2, 3, 5, 8, 13, 21...

ในเกม Fibonacci มักใช้ในการ:
- สร้างรูปแบบการเคลื่อนไหวของ AI ที่ดูเป็นธรรมชาติ
- กำหนดจำนวนศัตรูหรือไอเท็มที่เพิ่มขึ้นตาม level
- สร้าง pattern ในเกม puzzle หรือ rhythm game
- คำนวณระยะห่างหรือความเร็วที่เปลี่ยนแปลงแบบ progressive

**หลักการทำงานของ Fibonacci:**
- F(0) = 0, F(1) = 1
- F(n) = F(n-1) + F(n-2) สำหรับ n > 1

**Method Signature:**
```csharp
public int LCT02_RecursiveFibonacci(int n)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameter n
2. Base Case: ถ้า n <= 1 ให้ return n
3. Recursive Case: return Fibonacci(n-1) + Fibonacci(n-2)
4. คืนค่าผลลัพธ์เป็น int

**หมายเหตุ:** การใช้ Recursion แบบธรรมดากับ Fibonacci จะช้าสำหรับ n ใหญ่ เพราะมีการคำนวณซ้ำ (Time Complexity: O(2^n))

**Test Cases:**
1. **Input:** n = 6
   **Expected Return Value:**
   ```
   8
   ```

2. **Input:** n = 0
   **Expected Return Value:**
   ```
   0
   ```

3. **Input:** n = 1
   **Expected Return Value:**
   ```
   1
   ```

4. **Input:** n = 2
   **Expected Return Value:**
   ```
   1
   ```

5. **Input:** n = 3
   **Expected Return Value:**
   ```
   2
   ```

6. **Input:** n = 4
   **Expected Return Value:**
   ```
   3
   ```

7. **Input:** n = 5
   **Expected Return Value:**
   ```
   5
   ```

### 3. LCT03_RecursiveSumOfOneToN

**วัตถุประสงค์:** เรียนรู้การคำนวณผลรวมจาก 1 ถึง N ด้วย Recursion

**คำอธิบายปัญหา:**
คำนวณผลรวมของจำนวนเต็มบวกตั้งแต่ 1 ถึง n เช่น Sum(5) = 1 + 2 + 3 + 4 + 5 = 15

ในเกมสามารถใช้ในการ:
- คำนวณ experience points สะสม
- หาผลรวม damage หรือ score จากหลายแหล่ง
- คำนวณจำนวน resource ที่สะสมในแต่ละ level
- สร้างระบบการคำนวณแบบ accumulative

**หลักการทำงาน:**
- Sum(0) = 0 (Base Case)
- Sum(n) = n + Sum(n-1) (Recursive Case)

**Method Signature:**
```csharp
public int LCT03_RecursiveSumOfOneToN(int n)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameter n
2. Base Case: ถ้า n <= 0 ให้ return 0
3. Recursive Case: return n + SumOfOneToN(n-1)
4. คืนค่าผลลัพธ์เป็น int

**Test Cases:**
1. **Input:** n = 5
   **Expected Return Value:**
   ```
   15
   ```

2. **Input:** n = 0
   **Expected Return Value:**
   ```
   0
   ```

3. **Input:** n = 1
   **Expected Return Value:**
   ```
   1
   ```

4. **Input:** n = 3
   **Expected Return Value:**
   ```
   6
   ```

5. **Input:** n = 10
   **Expected Return Value:**
   ```
   55
   ```

6. **Input:** n = 2
   **Expected Return Value:**
   ```
   3
   ```

### 4. LCT04_RecursiveSumOfNumbers

**วัตถุประสงค์:** เรียนรู้การคำนวณผลรวมของ Array ด้วย Recursion

**คำอธิบายปัญหา:**
คำนวณผลรวมของตัวเลขทั้งหมดใน array โดยใช้ Recursion แทนการใช้ loop 

ในเกมสามารถใช้ในการ:
- รวม score หรือ points จาก array ของผู้เล่นหลายคน
- คำนวณ total damage จาก array ของอาวุธหรือ skills
- หา total value ของไอเท็มทั้งหมดใน inventory
- ประมวลผลข้อมูลแบบ recursive แทน iterative

**หลักการทำงาน:**
- ใช้ index เพื่อเดินผ่าน Array
- Base Case: เมื่อ index >= length, return 0
- Recursive Case: array[index] + Sum(array, index+1)

**Method Signature:**
```csharp
public int LCT04_RecursiveSumOfNumbers(int[] numbers)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameters: array และ index
2. Base Case: ถ้า index >= array.Length ให้ return 0
3. Recursive Case: return array[index] + SumOfNumbers(array, index+1)
4. เรียกใช้ helper method โดยเริ่มที่ index = 0
5. คืนค่าผลลัพธ์เป็น int

**หมายเหตุ:** Array ว่างจะให้ผลลัพธ์เป็น 0

**Test Cases:**
1. **Input:** numbers = [1, 2, 3, 4, 5]
   **Expected Return Value:**
   ```
   15
   ```

2. **Input:** numbers = []
   **Expected Return Value:**
   ```
   0
   ```

3. **Input:** numbers = [10]
   **Expected Return Value:**
   ```
   10
   ```

4. **Input:** numbers = [1, 2, 3]
   **Expected Return Value:**
   ```
   6
   ```

5. **Input:** numbers = [0, 0, 0]
   **Expected Return Value:**
   ```
   0
   ```

6. **Input:** numbers = [-1, 1]
   **Expected Return Value:**
   ```
   0
   ```

---

## Assignment Methods

### ASN01_RecursivePower

**วัตถุประสงค์:** คำนวณเลขยกกำลัง (Power) ด้วย Recursion

**คำอธิบายปัญหา:**
คำนวณค่า base^exponent โดยใช้ Recursion เช่น 2^3 = 2 × 2 × 2 = 8

ในเกมสามารถใช้ในการ:
- คำนวณ damage ที่เพิ่มขึ้นแบบ exponential ตาม level หรือ combo
- สร้างระบบ multiplier ที่ทวีคูณ (เช่น critical hit)
- คำนวณ growth rate ของ stats ต่างๆ
- สร้างระบบ progression ที่เพิ่มขึ้นอย่างรวดเร็ว

**ตัวอย่างการใช้งานในเกม:** 
- Damage = BaseDamage × Power(ComboMultiplier, ComboCount)
- ExpRequired = BaseExp × Power(LevelMultiplier, CurrentLevel)

**Method Signature:**
```csharp
public int ASN01_RecursivePower(int baseNum, int exponent)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameters: baseNum และ exponent
2. Base Case: ถ้า exponent == 0 ให้ return 1 (เพราะ x^0 = 1)
3. Recursive Case: return baseNum * Power(baseNum, exponent-1)
4. คืนค่าผลลัพธ์เป็น int

**หมายเหตุ:** โจทย์นี้สมมติว่า exponent เป็นจำนวนเต็มบวกหรือ 0

**Test Cases:**
1. **Input:** baseNum = 2, exponent = 3
   **Expected Return Value:**
   ```
   8
   ```

2. **Input:** baseNum = 5, exponent = 0
   **Expected Return Value:**
   ```
   1
   ```

3. **Input:** baseNum = 3, exponent = 2
   **Expected Return Value:**
   ```
   9
   ```

4. **Input:** baseNum = 4, exponent = 2
   **Expected Return Value:**
   ```
   16
   ```

5. **Input:** baseNum = 1, exponent = 5
   **Expected Return Value:**
   ```
   1
   ```

6. **Input:** baseNum = 10, exponent = 1
   **Expected Return Value:**
   ```
   10
   ```

### ASN02_IsPalindrome

**วัตถุประสงค์:** ตรวจสอบว่า String เป็น Palindrome หรือไม่ด้วย Recursion

**คำอธิบายปัญหา:**
Palindrome คือคำหรือข้อความที่มีลำดับตัวอักษรเหมือนเดิมเมื่ออ่านจากซ้ายไปขวาและขวาไปซ้าย เช่น "radar", "aba", "noon"

ในเกมสามารถใช้ในการ:
- สร้างปริศนาหรือ puzzle ที่ต้องหาคำที่เป็น palindrome
- ตรวจสอบรหัสผ่านหรือ code ที่มีรูปแบบพิเศษ
- สร้างระบบการตรวจสอบ pattern ในเกม word game
- ตรวจสอบความถูกต้องของ input ในเกม puzzle

**ตัวอย่างการใช้งานในเกม:** 
- Puzzle game ที่ต้องจัดเรียงตัวอักษรให้เป็น palindrome
- RPG ที่ต้องใช้ magic word ที่เป็น palindrome เพื่อปลดล็อค
- Word game ที่ให้คะแนนพิเศษสำหรับคำที่เป็น palindrome

**Method Signature:**
```csharp
public bool ASN02_IsPalindrome(string str)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameters: string, start index, end index
2. Base Case: ถ้า start >= end แสดงว่าตรวจสอบครบแล้ว return true
3. ถ้า str[start] != str[end] แสดงว่าไม่ใช่ palindrome return false
4. Recursive Case: return IsPalindrome(str, start+1, end-1)
5. คืนค่า true ถ้าเป็น palindrome หรือ false ถ้าไม่ใช่ palindrome (ชนิด bool)

**หมายเหตุ:** String ว่างและ string ที่มีตัวอักษรเดียวถือว่าเป็น palindrome การเปรียบเทียบใช้ตัวอักษรตาม input โดยตรง แยกตัวพิมพ์ใหญ่และเล็ก และไม่ตัดช่องว่างหรือเครื่องหมายออก

**Test Cases:**
1. **Input:** str = "radar"
   **Expected Return Value:**
   ```
   true
   ```

2. **Input:** str = "hello"
   **Expected Return Value:**
   ```
   false
   ```

3. **Input:** str = "a"
   **Expected Return Value:**
   ```
   true
   ```

4. **Input:** str = ""
   **Expected Return Value:**
   ```
   true
   ```

5. **Input:** str = "aba"
   **Expected Return Value:**
   ```
   true
   ```

6. **Input:** str = "abcba"
   **Expected Return Value:**
   ```
   true
   ```

7. **Input:** str = "ab"
   **Expected Return Value:**
   ```
   false
   ```

8. **Input:** str = "aa"
   **Expected Return Value:**
   ```
   true
   ```

### ASN03_RecursiveGCD

**วัตถุประสงค์:** คำนวณ Greatest Common Divisor (GCD) ด้วย Recursion โดยใช้ Euclidean Algorithm

**คำอธิบายปัญหา:**
GCD (Greatest Common Divisor) หรือ ห.ร.ม. (หารร่วมมาก) คือจำนวนเต็มบวกที่มากที่สุดที่หารทั้งสองจำนวนลงตัว เช่น GCD(48, 18) = 6

Euclidean Algorithm เป็นวิธีการหา GCD ที่มีประสิทธิภาพโดยใช้หลักการ:
- GCD(a, b) = GCD(b, a mod b)
- ทำซ้ำจนกว่า b = 0 แล้ว GCD คือ a

### การใช้งาน GCD ใน Game Development:

#### 1. **Screen Resolution & Aspect Ratio**
ใช้ GCD เพื่อลดทอน resolution ให้เป็น aspect ratio ที่เรียบง่าย
```
Example: Resolution 1920x1080
GCD(1920, 1080) = 120
Aspect Ratio = 1920/120 : 1080/120 = 16:9
```
- ใช้ในการออกแบบ UI ที่รองรับหลายความละเอียด
- คำนวณ viewport scaling ที่เหมาะสม
- จัดการ letterboxing/pillarboxing

#### 2. **Animation & Frame Rate Synchronization**
ซิงค์ animation cycles ที่มี frame rate ต่างกัน
```
Example: 
- Animation A: 30 frames/cycle
- Animation B: 20 frames/cycle
GCD(30, 20) = 10
ใช้ 10 frames เป็นหน่วยย่อยร่วมในการแบ่งรอบ
หากเริ่มพร้อมกัน จุดเริ่มรอบจะตรงกันทุก LCM(30, 20) = 60 frames
```
- ประสานการเคลื่อนไหวของตัวละครและ background
- ซิงค์ particle effects กับ main animation
- หาจังหวะที่ multiple animations ซ้ำกันพอดี

#### 3. **Grid System & Tile-based Games**
จัดการ grid size ที่เข้ากันได้
```
Example: 
- Character size: 48 pixels
- Tile size: 32 pixels
GCD(48, 32) = 16
Base unit = 16 pixels (ทั้ง character และ tile หารด้วย 16 ลงตัว)
```
- ออกแบบ tilemap ที่ object ขนาดต่างๆ fit กันได้
- คำนวณ collision detection ที่แม่นยำ
- จัดการ snap-to-grid functionality

#### 4. **Resource Management & Crafting System**
ลดทอนสูตร crafting ให้เรียบง่าย
```
Example: 
Recipe: 24 Wood + 18 Stone = 1 Item
GCD(24, 18) = 6
Simplified: 4 Wood + 3 Stone = 1 Item
```
- แสดงสูตร crafting ที่อ่านง่าย
- ลดทอน resource ratios ในเกม strategy
- คำนวณ conversion rates ระหว่าง resources

#### 5. **Rhythm & Music Games**
หาจังหวะที่ pattern ซ้ำกัน
```
Example:
- Beat Pattern A: repeats every 12 beats
- Beat Pattern B: repeats every 8 beats
GCD(12, 8) = 4
Common subdivision = 4 beats
Patterns restart together every LCM(12, 8) = 24 beats
```
- ออกแบบ rhythm patterns ที่ซับซ้อน
- ประสาน multiple music tracks
- สร้าง procedural music ที่มี pattern

#### 6. **Enemy Spawn & Wave System**
จัดการ spawn cycles ของศัตรูหลายชนิด
```
Example:
- Enemy Type A spawns every 30 seconds
- Enemy Type B spawns every 45 seconds
GCD(30, 45) = 15
Common scheduling unit = 15 seconds
If both start at time 0, they spawn together again
every LCM(30, 45) = 90 seconds
```
- ออกแบบ wave patterns ที่สมดุล
- สร้าง difficulty curves ที่น่าสนใจ
- ควบคุม spawn rate ของ multiple enemy types

#### 7. **Stat System & Damage Calculation**
ลดทอน damage ratios
```
Example:
Physical Damage: 150
Magic Damage: 100
GCD(150, 100) = 50
Simplified Ratio = 3:2
```
- แสดง stat ratios ที่เข้าใจง่าย
- สร้าง balanced character builds
- คำนวณ damage distribution

#### 8. **Procedural Generation**
สร้าง repeating patterns
```
Example:
Generate terrain features:
- Trees every 12 tiles
- Rocks every 18 tiles
GCD(12, 18) = 6
Common spacing = 6 tiles (can use as base unit)
```
- สร้าง procedural world ที่มี pattern
- จัดการ repeating elements
- ออกแบบ dungeon layouts

**ตัวอย่างโค้ดการใช้งานจริง:**
โค้ดส่วนนี้เป็นตัวอย่างภายใน class `StudentSolution` หลัง implement helper `GCD` แล้ว โดยใช้ `UnityEngine.Debug.Log` เพื่อแสดงผลในเกม การแสดงผลนี้ไม่ใช่ค่าที่ Test Cases ใช้ตรวจคำตอบ

```csharp
// Example 1: Aspect Ratio Calculator
int screenWidth = 1920;
int screenHeight = 1080;
int gcd = GCD(screenWidth, screenHeight);
UnityEngine.Debug.Log($"Aspect Ratio: {screenWidth/gcd}:{screenHeight/gcd}"); // 16:9

// Example 2: Grid Snap System
int objectSize = 48;
int gridSize = 32;
int snapUnit = GCD(objectSize, gridSize); // 16
// Object can snap to grid at multiples of 16 pixels

// Example 3: Crafting Recipe Simplification
int woodCost = 24;
int stoneCost = 18;
int simplifier = GCD(woodCost, stoneCost); // 6
UnityEngine.Debug.Log($"Simplified Recipe: {woodCost/simplifier} Wood + {stoneCost/simplifier} Stone");
// Output: 4 Wood + 3 Stone
```

**ตัวอย่างการใช้งานในเกม:**
- **UI Design:** ปรับ resolution และ aspect ratio อัตโนมัติ
- **Animation System:** ซิงค์ multiple animation loops
- **Tile-based Games:** คำนวณ grid alignment ที่สมบูรณ์แบบ
- **Strategy Games:** ลดทอน resource costs ให้อ่านง่าย
- **Rhythm Games:** หา beat synchronization points

**Method Signature:**
```csharp
public int ASN03_RecursiveGCD(int a, int b)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameters: a และ b
2. Base Case: ถ้า b == 0 ให้ return a
3. Recursive Case: return GCD(b, a % b)
4. คืนค่าผลลัพธ์เป็น int

**หมายเหตุ:** Algorithm นี้ทำงานได้รวดเร็วมาก (Time Complexity: O(log(min(a,b))))

**Test Cases:**
1. **Input:** a = 48, b = 18
   **Expected Return Value:**
   ```
   6
   ```

2. **Input:** a = 100, b = 75
   **Expected Return Value:**
   ```
   25
   ```

3. **Input:** a = 7, b = 3
   **Expected Return Value:**
   ```
   1
   ```

4. **Input:** a = 54, b = 24
   **Expected Return Value:**
   ```
   6
   ```

5. **Input:** a = 17, b = 13
   **Expected Return Value:**
   ```
   1
   ```

6. **Input:** a = 25, b = 15
   **Expected Return Value:**
   ```
   5
   ```

### ASN04_RecursiveBinarySearch

**วัตถุประสงค์:** ค้นหา Target ใน Array ที่เรียงลำดับด้วย Binary Search แบบ Recursion

**คำอธิบายปัญหา:**
Binary Search เป็น algorithm การค้นหาที่มีประสิทธิภาพสูงสำหรับข้อมูลที่เรียงลำดับแล้ว โดยแบ่งข้อมูลครึ่งหนึ่งในแต่ละรอบ

หลักการทำงาน:
1. หาตำแหน่งกลาง (mid) ของ array
2. ถ้าค่ากลางตรงกับ target ก็พบแล้ว
3. ถ้า target น้อยกว่าค่ากลาง ให้ค้นหาครึ่งซ้าย
4. ถ้า target มากกว่าค่ากลาง ให้ค้นหาครึ่งขวา
5. ทำซ้ำจนพบหรือหมด range

ในเกมสามารถใช้ในการ:
- ค้นหาตำแหน่งของผู้เล่นใน leaderboard ที่เรียงลำดับ
- หาไอเท็มใน inventory ที่เรียงตาม ID หรือ name
- ค้นหา NPC หรือ object ที่มี ID เฉพาะ
- หาข้อมูลใน database ที่มีการ index แล้ว

**ตัวอย่างการใช้งานในเกม:**
- ค้นหา player rank ใน sorted leaderboard
- หา skill ที่ต้องการจาก sorted skill list
- ค้นหา quest ที่มี ID เฉพาะในระบบ

**Method Signature:**
```csharp
public int ASN04_RecursiveBinarySearch(int[] arr, int target)
```

**Logic ที่ต้อง implement:**
1. สร้าง helper method แบบ recursive ที่รับ parameters: array, target, low, high
2. Base Case: ถ้า low > high แสดงว่าไม่พบ return -1
3. คำนวณ mid = low + (high - low) / 2
4. ถ้า arr[mid] == target return mid
5. ถ้า arr[mid] > target ค้นหาครึ่งซ้าย: return BinarySearch(arr, target, low, mid-1)
6. ถ้า arr[mid] < target ค้นหาครึ่งขวา: return BinarySearch(arr, target, mid+1, high)
7. คืนค่า index ที่พบ หรือ -1 ถ้าไม่พบ (ชนิด int)

**หมายเหตุ:** 
- Array ต้องเรียงลำดับจากน้อยไปมากก่อน
- Time Complexity: O(log n) เร็วกว่า Sequential Search มาก
- แต่ต้องมีการเรียงลำดับข้อมูลก่อน

**Test Cases:**
1. **Input:** arr = [1, 3, 5, 7, 9], target = 5
   **Expected Return Value:**
   ```
   2
   ```

2. **Input:** arr = [1, 2, 3, 4, 5], target = 6
   **Expected Return Value:**
   ```
   -1
   ```

3. **Input:** arr = [10], target = 10
   **Expected Return Value:**
   ```
   0
   ```

4. **Input:** arr = [1, 2, 3], target = 0
   **Expected Return Value:**
   ```
   -1
   ```

5. **Input:** arr = [2, 4, 6, 8, 10], target = 4
   **Expected Return Value:**
   ```
   1
   ```

6. **Input:** arr = [1, 3, 5], target = 1
   **Expected Return Value:**
   ```
   0
   ```

7. **Input:** arr = [1, 2, 3, 4], target = 5
   **Expected Return Value:**
   ```
   -1
   ```

8. **Input:** arr = [5], target = 6
   **Expected Return Value:**
   ```
   -1
   ```

---

## 💡 เทคนิคการเขียนโปรแกรม

### 1. การจัดการ Stack Overflow
- Recursion ใช้ Stack Memory
- สำหรับ input ใหญ่ อาจเกิด Stack Overflow
- ในงานจริงอาจใช้ Iterative สำหรับปัญหาใหญ่ แต่แบบฝึกหัดนี้ให้ใช้ Recursion เพื่อฝึก Base Case และ Recursive Case

### 2. การเลือกใช้ Recursion
- **ปัญหาที่แบ่งได้**: Factorial, Fibonacci
- **ปัญหาที่ซับซ้อน**: Binary Search, GCD
- **หลีกเลี่ยง**: สำหรับ loop ธรรมดา

### 3. การจัดการ Edge Cases
- **Input เป็น 0 หรือ 1**: ตรวจสอบ Base Case
- **Array ว่าง**: ตรวจสอบ length
- **String ว่าง**: เป็น Palindrome

---

## 🚀 การประยุกต์ใช้ในเกม

### 1. RPG Game
- คำนวณ damage หรือ stat ที่เพิ่มขึ้นแบบ exponential
- ตรวจสอบรหัสหรือชื่อที่เป็น Palindrome
- ค้นหาใน leaderboard ที่เรียงลำดับ

### 2. Strategy Game
- คำนวณจำนวนวิธีการจัดกองทัพ (Factorial)
- หา GCD สำหรับการลดทอน resource
- ค้นหาตำแหน่งใน map ที่เรียงลำดับ

### 3. Puzzle Game
- ตรวจสอบ pattern ที่เป็น Palindrome
- คำนวณ Fibonacci สำหรับการเติบโตของ puzzle pieces
- Binary Search ใน sequence ที่เรียงลำดับ
