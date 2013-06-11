﻿Public Module BinderTests_Zork1

#Region "Zork1_4E3B"

#Region "ZCode"
    ' 4e3b:  b2 ...                  PRINT           "a "
    ' 4e3e:  aa 01                   PRINT_OBJ       L00
    ' 4e40:  b0                      RTRUE
#End Region

    <Fact>
    Sub Zork1_4E3B()
        Dim expected =
<![CDATA[
# temps: 8

LABEL 00
    print: "a "
    temp00 <- L00
    temp01 <- (temp00 - 1)
    temp02 <- (temp01 * 9)
    temp03 <- (temp02 + 2ee)
    temp04 <- (temp03 + 7)
    temp05 <- read-word(temp04)
    temp06 <- read-byte(temp05)
    temp07 <- (temp05 + 1)
    print: read-text(temp07, temp06)
    return: 1
]]>

        TestBinder(Zork1, &H4E38, expected)
    End Sub

#End Region
#Region "Zork1_4E42"

#Region "ZCode"
    ' 4e45:  a0 4c cb                JZ              G3c [TRUE] 4e51
    ' 4e48:  e7 7f 64 00             RANDOM          #64 -> -(SP)
    ' 4e4c:  63 01 00 c1             JG              L00,(SP)+ [TRUE] RTRUE
    ' 4e50:  b1                      RFALSE
    ' 4e51:  e7 3f 01 2c 00          RANDOM          #012c -> -(SP)
    ' 4e56:  63 01 00 c1             JG              L00,(SP)+ [TRUE] RTRUE
    ' 4e5a:  b1                      RFALSE
#End Region

    <Fact>
    Sub Zork1_4E42()

        Dim expected =
<![CDATA[
# temps: 5

LABEL 00
    temp00 <- read-word(22e9)
    if (temp00 = 0) is true then
        jump-to: LABEL 06
LABEL 01
    if (int16(64) > 0) is false then
        jump-to: LABEL 03
LABEL 02
    push-SP: random(int16(64))
    jump-to: LABEL 04
LABEL 03
    randomize(int16(64))
    push-SP: 0
LABEL 04
    temp01 <- L00
    temp02 <- pop-SP
    if (int16(temp01) > int16(temp02)) is true then
        return: 1
LABEL 05
    return: 0
LABEL 06
    if (int16(012c) > 0) is false then
        jump-to: LABEL 08
LABEL 07
    push-SP: random(int16(012c))
    jump-to: LABEL 09
LABEL 08
    randomize(int16(012c))
    push-SP: 0
LABEL 09
    temp03 <- L00
    temp04 <- pop-SP
    if (int16(temp03) > int16(temp04)) is true then
        return: 1
LABEL 0a
    return: 0
]]>

        TestBinder(Zork1, &H4E42, expected)
    End Sub

#End Region
#Region "Zork1_4E5C"

#Region "ZCode"
    ' 4e5f:  4f 01 00 00             LOADW           L00,#00 -> -(SP)
    ' 4e63:  e7 bf 00 00             RANDOM          (SP)+ -> -(SP)
    ' 4e67:  6f 01 00 00             LOADW           L00,(SP)+ -> -(SP)
    ' 4e6b:  b8                      RET_POPPED
#End Region

    <Fact>
    Sub Zork1_4E5C()
        Dim expected =
<![CDATA[
# temps: 4

LABEL 00
    temp00 <- L00
    temp01 <- read-word(temp00)
    if (int16(temp01) > 0) is false then
        jump-to: LABEL 02
LABEL 01
    push-SP: random(int16(temp01))
    jump-to: LABEL 03
LABEL 02
    randomize(int16(temp01))
    push-SP: 0
LABEL 03
    temp02 <- L00
    temp03 <- pop-SP
    return: read-word(temp02 + (temp03 * 2))
]]>

        TestBinder(Zork1, &H4E5C, expected)
    End Sub

#End Region
#Region "Zork1_4E6C"

#Region "ZCode"
    ' 4e79:  4f 01 00 02             LOADW           L00,#00 -> L01
    ' 4e7d:  4f 01 01 03             LOADW           L00,#01 -> L02
    ' 4e81:  96 02                   DEC             L01
    ' 4e83:  54 01 02 01             ADD             L00,#02 -> L00
    ' 4e87:  56 03 02 00             MUL             L02,#02 -> -(SP)
    ' 4e8b:  74 01 00 06             ADD             L00,(SP)+ -> L05
    ' 4e8f:  75 02 03 00             SUB             L01,L02 -> -(SP)
    ' 4e93:  e7 bf 00 04             RANDOM          (SP)+ -> L03
    ' 4e97:  6f 06 04 05             LOADW           L05,L03 -> L04
    ' 4e9b:  4f 06 01 00             LOADW           L05,#01 -> -(SP)
    ' 4e9f:  e1 ab 06 04 00          STOREW          L05,L03,(SP)+
    ' 4ea4:  e1 9b 06 01 05          STOREW          L05,#01,L04
    ' 4ea9:  95 03                   INC             L02
    ' 4eab:  61 03 02 45             JE              L02,L01 [FALSE] 4eb2
    ' 4eaf:  0d 03 00                STORE           L02,#00
    ' 4eb2:  e1 9b 01 00 03          STOREW          L00,#00,L02
    ' 4eb7:  ab 05                   RET             L04
#End Region

    <Fact>
    Sub Zork1_4E6C()
        Dim expected =
<![CDATA[
# temps: 25

LABEL 00
    temp00 <- L00
    L01 <- read-word(temp00)
    temp01 <- L00
    L02 <- read-word(temp01 + 2)
    temp02 <- L01
    L01 <- (int16(temp02) - int16(1))
    temp03 <- L00
    L00 <- (int16(temp03) + int16(02))
    temp04 <- L02
    push-SP: (int16(temp04) * int16(02))
    temp05 <- L00
    temp06 <- pop-SP
    L05 <- (int16(temp05) + int16(temp06))
    temp07 <- L01
    temp08 <- L02
    temp09 <- (int16(temp07) - int16(temp08))
    if (int16(temp09) > 0) is false then
        jump-to: LABEL 02
LABEL 01
    L03 <- random(int16(temp09))
    jump-to: LABEL 03
LABEL 02
    randomize(int16(temp09))
    L03 <- 0
LABEL 03
    temp0a <- L05
    temp0b <- L03
    L04 <- read-word(temp0a + (temp0b * 2))
    temp0c <- L05
    push-SP: read-word(temp0c + 2)
    temp0d <- L05
    temp0e <- L03
    temp0f <- pop-SP
    write-word(temp0d + (temp0e * 2)) <- temp0f
    temp10 <- L05
    temp11 <- L04
    write-word(temp10 + 2) <- temp11
    temp12 <- L02
    L02 <- (int16(temp12) + int16(1))
    temp13 <- L02
    temp14 <- L01
    temp15 <- (temp13 = temp14)
    if (temp15) is false then
        jump-to: LABEL 05
LABEL 04
    L02 <- 00
LABEL 05
    temp16 <- L00
    temp17 <- L02
    write-word(temp16) <- temp17
    temp18 <- L04
    return: temp18
]]>

        TestBinder(Zork1, &H4E6C, expected)
    End Sub

#End Region
#Region "Zork1_4EBA"

#Region "ZCode"
    ' 4ebb:  41 88 2b 40             JE              G78,#2b [FALSE] RFALSE
    ' 4ebf:  e0 1f 48 5d a3 00       CALL            90ba (#a3) -> -(SP)
    ' 4ec5:  b1                      RFALSE       
#End Region

    <Fact>
    Sub Zork1_4EBA()
        Dim expected =
<![CDATA[
# temps: 2

LABEL 00
    temp00 <- read-word(2361)
    temp01 <- (temp00 = 2b)
    if (temp01) is false then
        return: 0
LABEL 01
    push-SP: call 90ba (a3)
    return: 0
]]>

        TestBinder(Zork1, &H4EBA, expected)
    End Sub

#End Region
#Region "Zork1_4EC6"

#Region "ZCode"
    ' 4ec7:  a0 3e d9                JZ              G2e [TRUE] 4ee1
    ' 4eca:  0a ae 0b 44             TEST_ATTR       "grating",#0b [FALSE] 4ed0
    ' 4ece:  9b 39                   RET             #39
    ' 4ed0:  b2 ...                  PRINT           "The grating is closed!"
    ' 4ed9:  bb                      NEW_LINE        
    ' 4eda:  e0 1f 4a 98 ae 00       CALL            9530 (#ae) -> -(SP)
    ' 4ee0:  b1                      RFALSE          
    ' 4ee1:  b2 ...                  PRINT           "You can't go that way."
    ' 4eec:  bb                      NEW_LINE        
    ' 4eed:  b1                      RFALSE     
#End Region

    <Fact>
    Sub Zork1_4EC6()
        Dim expected =
<![CDATA[
# temps: 4

LABEL 00
    temp00 <- read-word(22cd)
    if (temp00 = 0) is true then
        jump-to: LABEL 04
LABEL 01
    temp01 <- read-byte(904)
    temp02 <- (temp01 & 0010)
    temp03 <- (temp02 <> 0)
    if (temp03 = 1) is false then
        jump-to: LABEL 03
LABEL 02
    return: 39
LABEL 03
    print: "The grating is closed!"
    print: "\n"
    push-SP: call 9530 (ae)
    return: 0
LABEL 04
    print: "You can't go that way."
    print: "\n"
    return: 0
]]>

        TestBinder(Zork1, &H4EC6, expected)
    End Sub

#End Region
#Region "Zork1_4EEE"

#Region "ZCode"
    ' 4ef1:  41 01 01 40             JE              L00,#01 [FALSE] RFALSE
    ' 4ef5:  41 88 45 40             JE              G78,#45 [FALSE] RFALSE
    ' 4ef9:  a0 86 40                JZ              G76 [FALSE] RFALSE
    ' 4efc:  e0 0f 83 33 98 3b 00    CALL            10666 (S148) -> -(SP)
    ' 4f03:  b0                      RTRUE           
#End Region

    <Fact>
    Sub Zork1_4EEE()
        Dim expected =
<![CDATA[
# temps: 5

LABEL 00
    temp00 <- L00
    temp01 <- (temp00 = 01)
    if (temp01) is false then
        return: 0
LABEL 01
    temp02 <- read-word(2361)
    temp03 <- (temp02 = 45)
    if (temp03) is false then
        return: 0
LABEL 02
    temp04 <- read-word(235d)
    if (temp04 = 0) is false then
        return: 0
LABEL 03
    push-SP: call 10666 (983b)
    return: 1
]]>

        TestBinder(Zork1, &H4EEE, expected)
    End Sub

#End Region
#Region "Zork1_4F04"

#Region "ZCode"
    ' 4f05:  e0 03 2a 39 80 10 ff ff 00 
    '                               CALL            5472 (#8010,#ffff) -> -(SP)
    ' 4f0e:  e1 97 00 00 01          STOREW          (SP)+,#00,#01
    ' 4f13:  e0 03 2a 39 80 7c ff ff 00 
    '                               CALL            5472 (#807c,#ffff) -> -(SP)
    ' 4f1c:  e0 03 2a 39 80 f0 ff ff 00 
    '                               CALL            5472 (#80f0,#ffff) -> -(SP)
    ' 4f25:  e1 97 00 00 01          STOREW          (SP)+,#00,#01
    ' 4f2a:  e0 07 2a 39 6f 6a 28 00 CALL            5472 (#6f6a,#28) -> -(SP)
    ' 4f32:  e0 07 2a 39 6f 55 c8 00 CALL            5472 (#6f55,#c8) -> -(SP)
    ' 4f3a:  e3 57 9c 06 04          PUT_PROP        "magic boat",#06,#04
    ' 4f3f:  54 20 02 00             ADD             G10,#02 -> -(SP)
    ' 4f43:  e1 9b 1a 01 00          STOREW          G0a,#01,(SP)+
    ' 4f48:  54 20 04 00             ADD             G10,#04 -> -(SP)
    ' 4f4c:  e1 9b 1a 02 00          STOREW          G0a,#02,(SP)+
    ' 4f51:  54 1e 02 00             ADD             G0e,#02 -> -(SP)
    ' 4f55:  e1 9b 19 02 00          STOREW          G09,#02,(SP)+
    ' 4f5a:  54 1e 04 00             ADD             G0e,#04 -> -(SP)
    ' 4f5e:  e1 9b 19 03 00          STOREW          G09,#03,(SP)+
    ' 4f63:  54 1d 02 00             ADD             G0d,#02 -> -(SP)
    ' 4f67:  e1 9b 18 01 00          STOREW          G08,#01,(SP)+
    ' 4f6c:  54 1c 02 00             ADD             G0c,#02 -> -(SP)
    ' 4f70:  e1 9b 18 03 00          STOREW          G08,#03,(SP)+
    ' 4f75:  0d 10 b4                STORE           G00,#b4
    ' 4f78:  e0 1f 4a 98 a0 00       CALL            9530 (#a0) -> -(SP)
    ' 4f7e:  4a 10 03 c8             TEST_ATTR       G00,#03 [TRUE] 4f88
    ' 4f82:  e0 3f 37 70 00          CALL            6ee0 -> -(SP)
    ' 4f87:  bb                      NEW_LINE        
    ' 4f88:  0d 52 01                STORE           G42,#01
    ' 4f8b:  0d 7f 04                STORE           G6f,#04
    ' 4f8e:  2d 90 7f                STORE           G80,G6f
    ' 4f91:  6e 7f 10                INSERT_OBJ      G6f,G00
    ' 4f94:  e0 3f 3f 02 00          CALL            7e04 -> -(SP)
    ' 4f99:  e0 3f 2a 95 00          CALL            552a -> -(SP)
    ' 4f9e:  8c ff 66                JUMP            4f05
#End Region

    <Fact>
    Sub Zork1_4F04()
        Dim expected =
<![CDATA[
# temps: 96

LABEL 00
    temp00 <- call 5472 (8010, ffff)
    write-word(temp00) <- 01
    push-SP: call 5472 (807c, ffff)
    push-SP: call 5472 (80f0, ffff)
    temp01 <- pop-SP
    write-word(temp01) <- 01
    push-SP: call 5472 (6f6a, 28)
    push-SP: call 5472 (6f55, c8)
    temp02 <- read-word(868)
    temp03 <- read-byte(temp02)
    temp04 <- (temp02 + 1)
    temp05 <- (temp03 * 2)
    temp06 <- (temp04 + temp05)
    temp07 <- uint16(temp06)
    temp08 <- 0
LABEL 01
    temp09 <- read-byte(temp07)
    if ((temp09 & 1f) <= 06) is false then
        jump-to: LABEL 03
LABEL 02
    temp08 <- 1
    jump-to: LABEL 04
LABEL 03
    temp0a <- read-byte(temp07)
    temp0b <- ((temp07 + 1) + ((temp0a >> 5) + 1))
    temp07 <- uint16(temp0b)
LABEL 04
    if (temp08 = 0) is true then
        jump-to: LABEL 01
    if ((temp09 & 1f) <> 06) is false then
        jump-to: LABEL 06
LABEL 05
    RUNTIME EXCEPTION: Property not found!
LABEL 06
    temp07 <- (temp07 + 1)
    if ((temp09 & e0) = 0) is false then
        jump-to: LABEL 08
LABEL 07
    write-byte(temp07) <- byte(04)
    jump-to: LABEL 09
LABEL 08
    write-word(temp07) <- 04
LABEL 09
    temp0c <- read-word(2291)
    push-SP: (int16(temp0c) + int16(02))
    temp0d <- read-word(2285)
    temp0e <- pop-SP
    write-word(temp0d + 2) <- temp0e
    temp0f <- read-word(2291)
    push-SP: (int16(temp0f) + int16(04))
    temp10 <- read-word(2285)
    temp11 <- pop-SP
    write-word(temp10 + 4) <- temp11
    temp12 <- read-word(228d)
    push-SP: (int16(temp12) + int16(02))
    temp13 <- read-word(2283)
    temp14 <- pop-SP
    write-word(temp13 + 4) <- temp14
    temp15 <- read-word(228d)
    push-SP: (int16(temp15) + int16(04))
    temp16 <- read-word(2283)
    temp17 <- pop-SP
    write-word(temp16 + 6) <- temp17
    temp18 <- read-word(228b)
    push-SP: (int16(temp18) + int16(02))
    temp19 <- read-word(2281)
    temp1a <- pop-SP
    write-word(temp19 + 2) <- temp1a
    temp1b <- read-word(2289)
    push-SP: (int16(temp1b) + int16(02))
    temp1c <- read-word(2281)
    temp1d <- pop-SP
    write-word(temp1c + 6) <- temp1d
    write-word(2271) <- b4
    push-SP: call 9530 (a0)
    temp1e <- read-word(2271)
    temp1f <- (temp1e - 1)
    temp20 <- (temp1f * 9)
    temp21 <- (temp20 + 2ee)
    temp22 <- read-byte(temp21)
    temp23 <- (temp22 & 0010)
    temp24 <- (temp23 <> 0)
    if (temp24 = 1) is true then
        jump-to: LABEL 0b
LABEL 0a
    push-SP: call 6ee0 ()
    print: "\n"
LABEL 0b
    write-word(22f5) <- 01
    write-word(234f) <- 04
    temp25 <- read-word(234f)
    write-word(2371) <- temp25
    temp26 <- read-word(234f)
    temp27 <- read-word(2271)
    temp28 <- 0
    temp29 <- (temp26 - 1)
    temp2a <- (temp29 * 9)
    temp2b <- (temp2a + 2ee)
    temp2c <- (temp2b + 5)
    temp2d <- read-byte(temp2c)
    temp2e <- (temp26 - 1)
    temp2f <- (temp2e * 9)
    temp30 <- (temp2f + 2ee)
    temp31 <- (temp30 + 4)
    temp32 <- read-byte(temp31)
    if (temp32 = 0) is false then
        jump-to: LABEL 0d
LABEL 0c
    temp33 <- 0
    jump-to: LABEL 0e
LABEL 0d
    temp34 <- (temp32 - 1)
    temp35 <- (temp34 * 9)
    temp36 <- (temp35 + 2ee)
    temp37 <- (temp36 + 6)
    temp38 <- read-byte(temp37)
    temp33 <- temp38
LABEL 0e
    if (temp33 <> temp26) is false then
        jump-to: LABEL 14
LABEL 0f
    temp39 <- temp33
LABEL 10
    temp3a <- (temp39 - 1)
    temp3b <- (temp3a * 9)
    temp3c <- (temp3b + 2ee)
    temp3d <- (temp3c + 5)
    temp3e <- read-byte(temp3d)
    if (temp3e = temp26) is false then
        jump-to: LABEL 12
LABEL 11
    temp28 <- temp39
    temp39 <- 0
    jump-to: LABEL 13
LABEL 12
    temp39 <- temp3e
LABEL 13
    if (temp39 <> 0) is true then
        jump-to: LABEL 10
LABEL 14
    if (temp28 <> 0) is false then
        jump-to: LABEL 16
LABEL 15
    temp3f <- (temp28 - 1)
    temp40 <- (temp3f * 9)
    temp41 <- (temp40 + 2ee)
    temp42 <- (temp41 + 5)
    write-byte(temp42) <- temp2d
LABEL 16
    if (temp33 = temp26) is false then
        jump-to: LABEL 18
LABEL 17
    temp43 <- (temp32 - 1)
    temp44 <- (temp43 * 9)
    temp45 <- (temp44 + 2ee)
    temp46 <- (temp45 + 6)
    write-byte(temp46) <- temp2d
LABEL 18
    temp47 <- (temp26 - 1)
    temp48 <- (temp47 * 9)
    temp49 <- (temp48 + 2ee)
    temp4a <- (temp49 + 4)
    write-byte(temp4a) <- 0
    temp4b <- (temp26 - 1)
    temp4c <- (temp4b * 9)
    temp4d <- (temp4c + 2ee)
    temp4e <- (temp4d + 5)
    write-byte(temp4e) <- 0
    if (temp27 <> 0) is false then
        jump-to: LABEL 1a
LABEL 19
    temp4f <- (temp26 - 1)
    temp50 <- (temp4f * 9)
    temp51 <- (temp50 + 2ee)
    temp52 <- (temp51 + 4)
    write-byte(temp52) <- temp27
    temp53 <- (temp27 - 1)
    temp54 <- (temp53 * 9)
    temp55 <- (temp54 + 2ee)
    temp56 <- (temp55 + 6)
    temp57 <- read-byte(temp56)
    temp58 <- (temp26 - 1)
    temp59 <- (temp58 * 9)
    temp5a <- (temp59 + 2ee)
    temp5b <- (temp5a + 5)
    write-byte(temp5b) <- temp57
    temp5c <- (temp27 - 1)
    temp5d <- (temp5c * 9)
    temp5e <- (temp5d + 2ee)
    temp5f <- (temp5e + 6)
    write-byte(temp5f) <- temp26
LABEL 1a
    push-SP: call 7e04 ()
    push-SP: call 552a ()
    jump-to: LABEL 00
]]>

        TestBinder(Zork1, &H4F04, expected)
    End Sub

#End Region
#Region "Zork1_552A"

#Region "ZCode"
    ' 553f:  0d 04 00                STORE           L03,#00
    ' 5542:  0d 05 00                STORE           L04,#00
    ' 5545:  0d 08 01                STORE           L07,#01
    ' 5548:  e0 3f 2c 40 8f          CALL            5880 -> G7f
    ' 554d:  a0 8f 81 fc             JZ              G7f [TRUE] 574b
    ' 5551:  6f 65 61 01             LOADW           G55,G51 -> L00
    ' 5555:  6f 66 61 02             LOADW           G56,G51 -> L01
    ' 5559:  a0 02 48                JZ              L01 [FALSE] 5562
    ' 555c:  e8 bf 02                PUSH            L01
    ' 555f:  8c 00 33                JUMP            5593
    ' 5562:  43 02 01 58             JG              L01,#01 [FALSE] 557c
    ' 5566:  2d 06 66                STORE           L05,G56
    ' 5569:  a0 01 48                JZ              L00 [FALSE] 5572
    ' 556c:  0d 05 00                STORE           L04,#00
    ' 556f:  8c 00 06                JUMP            5576
    ' 5572:  4f 65 01 05             LOADW           G55,#01 -> L04
    ' 5576:  e8 bf 02                PUSH            L01
    ' 5579:  8c 00 19                JUMP            5593
    ' 557c:  43 01 01 52             JG              L00,#01 [FALSE] 5590
    ' 5580:  0d 08 00                STORE           L07,#00
    ' 5583:  2d 06 65                STORE           L05,G55
    ' 5586:  4f 66 01 05             LOADW           G56,#01 -> L04
    ' 558a:  e8 bf 01                PUSH            L00
    ' 558d:  8c 00 05                JUMP            5593
    ' 5590:  e8 7f 01                PUSH            #01
    ' 5593:  2d 03 00                STORE           L02,(SP)+
    ' 5596:  a0 05 4a                JZ              L04 [FALSE] 55a1
    ' 5599:  41 01 01 46             JE              L00,#01 [FALSE] 55a1
    ' 559d:  4f 65 01 05             LOADW           G55,#01 -> L04
    ' 55a1:  41 88 89 4c             JE              G78,#89 [FALSE] 55af
    ' 55a5:  e0 2b 2b be 88 86 07    CALL            577c (G78,G76) -> L06
    ' 55ac:  8c 01 6a                JUMP            5717
    ' 55af:  a0 03 00 4f             JZ              L02 [FALSE] 5600
    ' 55b3:  50 83 00 00             LOADB           G73,#00 -> -(SP)
    ' 55b7:  49 00 03 00             AND             (SP)+,#03 -> -(SP)
    ' 55bb:  a0 00 4e                JZ              (SP)+ [FALSE] 55ca
    ' 55be:  e0 2f 2b be 88 07       CALL            577c (G78) -> L06
    ' 55c4:  0d 86 00                STORE           G76,#00
    ' 55c7:  8c 01 4f                JUMP            5717
    ' 55ca:  a0 52 53                JZ              G42 [FALSE] 55de
    ' 55cd:  b2 ...                  PRINT           "It's too dark to see."
    ' 55da:  bb                      NEW_LINE        
    ' 55db:  8c 01 3b                JUMP            5717
    ' 55de:  b2 ...                  PRINT           "It's not clear what you're referring to."
    ' 55f9:  bb                      NEW_LINE        
    ' 55fa:  0d 07 00                STORE           L06,#00
    ' 55fd:  8c 01 19                JUMP            5717
    ' 5600:  0d 8a 00                STORE           G7a,#00
    ' 5603:  0d 8b 00                STORE           G7b,#00
    ' 5606:  43 03 01 45             JG              L02,#01 [FALSE] 560d
    ' 560a:  0d 8b 01                STORE           G7b,#01
    ' 560d:  0d 0a 00                STORE           L09,#00
    ' 5610:  25 04 03 00 5b          INC_CHK         L03,L02 [FALSE] 566e
    ' 5615:  43 8a 00 00 3d          JG              G7a,#00 [FALSE] 5655
    ' 561a:  b2 ...                  PRINT           "The "
    ' 561d:  61 8a 03 c5             JE              G7a,L02 [TRUE] 5624
    ' 5621:  b2 ...                  PRINT           "other "
    ' 5624:  b2 ...                  PRINT           "object"
    ' 5629:  41 8a 01 c5             JE              G7a,#01 [TRUE] 5630
    ' 562d:  b2 ...                  PRINT           "s"
    ' 5630:  b2 ...                  PRINT           " that you mentioned "
    ' 563d:  41 8a 01 c8             JE              G7a,#01 [TRUE] 5647
    ' 5641:  b2 ...                  PRINT           "are"
    ' 5644:  8c 00 05                JUMP            564a
    ' 5647:  b2 ...                  PRINT           "is"
    ' 564a:  b2 ...                  PRINT           "n't here."
    ' 5651:  bb                      NEW_LINE
    ' 5652:  8c 00 c4                JUMP            5717
    ' 5655:  a0 0a 00 c0             JZ              L09 [FALSE] 5717
    ' 5659:  b2 ...                  PRINT           "There's nothing here you can take."
    ' 566a:  bb                      NEW_LINE
    ' 566b:  8c 00 ab                JUMP            5717
    ' 566e:  a0 08 c9                JZ              L07 [TRUE] 5678
    ' 5671:  6f 66 04 09             LOADW           G56,L03 -> L08
    ' 5675:  8c 00 06                JUMP            567c
    ' 5678:  6f 65 04 09             LOADW           G55,L03 -> L08
    ' 567c:  a0 08 c8                JZ              L07 [TRUE] 5685
    ' 567f:  e8 bf 09                PUSH            L08
    ' 5682:  8c 00 05                JUMP            5688
    ' 5685:  e8 bf 05                PUSH            L04
    ' 5688:  2d 86 00                STORE           G76,(SP)+
    ' 568b:  a0 08 c8                JZ              L07 [TRUE] 5694
    ' 568e:  e8 bf 05                PUSH            L04
    ' 5691:  8c 00 05                JUMP            5697
    ' 5694:  e8 bf 09                PUSH            L08
    ' 5697:  2d 87 00                STORE           G77,(SP)+
    ' 569a:  43 03 01 d1             JG              L02,#01 [TRUE] 56ad
    ' 569e:  4f 74 06 00             LOADW           G64,#06 -> -(SP)
    ' 56a2:  4f 00 00 00             LOADW           (SP)+,#00 -> -(SP)
    ' 56a6:  c1 8f 00 3b 7c 00 59    JE              (SP)+,"all" [FALSE] 5704
    ' 56ad:  41 09 0b 47             JE              L08,#0b [FALSE] 56b6
    ' 56b1:  95 8a                   INC             G7a
    ' 56b3:  8c ff 5c                JUMP            5610
    ' 56b6:  41 88 5d 5a             JE              G78,#5d [FALSE] 56d2
    ' 56ba:  a0 87 d7                JZ              G77 [TRUE] 56d2
    ' 56bd:  4f 74 06 00             LOADW           G64,#06 -> -(SP)
    ' 56c1:  4f 00 00 00             LOADW           (SP)+,#00 -> -(SP)
    ' 56c5:  c1 8f 00 3b 7c 49       JE              (SP)+,"all" [FALSE] 56d2
    ' 56cb:  66 86 87 c5             JIN             G76,G77 [TRUE] 56d2
    ' 56cf:  8c ff 40                JUMP            5610
    ' 56d2:  41 60 01 62             JE              G50,#01 [FALSE] 56f6
    ' 56d6:  41 88 5d 5e             JE              G78,#5d [FALSE] 56f6
    ' 56da:  a3 09 00                GET_PARENT      L08 -> -(SP)
    ' 56dd:  c1 ab 00 7f 10 ca       JE              (SP)+,G6f,G00 [TRUE] 56eb
    ' 56e3:  a3 09 00                GET_PARENT      L08 -> -(SP)
    ' 56e6:  4a 00 0a 3f 27          TEST_ATTR       (SP)+,#0a [FALSE] 5610
    ' 56eb:  4a 09 11 c9             TEST_ATTR       L08,#11 [TRUE] 56f6
    ' 56ef:  4a 09 0d c5             TEST_ATTR       L08,#0d [TRUE] 56f6
    ' 56f3:  8c ff 1c                JUMP            5610
    ' 56f6:  41 09 0c 47             JE              L08,#0c [FALSE] 56ff
    ' 56fa:  aa 7b                   PRINT_OBJ       G6b
    ' 56fc:  8c 00 04                JUMP            5701
    ' 56ff:  aa 09                   PRINT_OBJ       L08
    ' 5701:  b2 ...                  PRINT           ": "
    ' 5704:  0d 0a 01                STORE           L09,#01
    ' 5707:  e0 2a 2b be 88 86 87 07 CALL            577c (G78,G76,G77) -> L06
    ' 570f:  41 07 02 3e fe          JE              L06,#02 [FALSE] 5610
    ' 5714:  8c 00 02                JUMP            5717
    ' 5717:  41 07 02 ce             JE              L06,#02 [TRUE] 5727
    ' 571b:  a3 7f 00                GET_PARENT      G6f -> -(SP)
    ' 571e:  51 00 11 00             GET_PROP        (SP)+,#11 -> -(SP)
    ' 5722:  e0 9f 00 06 07          CALL            (SP)+ (#06) -> L06
    ' 5727:  c1 95 88 08 89 0f d5    JE              G78,#08,#89,#0f [TRUE] 5741
    ' 572e:  c1 95 88 0c 09 07 45    JE              G78,#0c,#09,#07 [FALSE] 5738
    ' 5735:  8c 00 0b                JUMP            5741
    ' 5738:  2d 8e 88                STORE           G7e,G78
    ' 573b:  2d 8d 86                STORE           G7d,G76
    ' 573e:  2d 8c 87                STORE           G7c,G77
    ' 5741:  41 07 02 4b             JE              L06,#02 [FALSE] 574e
    ' 5745:  0d 7c 00                STORE           G6c,#00
    ' 5748:  8c 00 05                JUMP            574e
    ' 574b:  0d 7c 00                STORE           G6c,#00
    ' 574e:  a0 8f bd ef             JZ              G7f [TRUE] 553f
    ' 5752:  c1 95 88 02 01 6f bd e7 JE              G78,#02,#01,#6f [TRUE] 553f
    ' 575a:  c1 95 88 0c 08 00 bd df JE              G78,#0c,#08,#00 [TRUE] 553f
    ' 5762:  c1 95 88 09 06 05 bd d7 JE              G78,#09,#06,#05 [TRUE] 553f
    ' 576a:  c1 95 88 07 0b 0a 45    JE              G78,#07,#0b,#0a [FALSE] 5774
    ' 5771:  8c fd cd                JUMP            553f
    ' 5774:  e0 3f 2a 62 07          CALL            54c4 -> L06
    ' 5779:  8c fd c5                JUMP            553f
#End Region

    <Fact>
    Sub Zork1_552A()
        Dim expected =
<![CDATA[
# temps: 199

LABEL 00
    L03 <- 00
    L04 <- 00
    L07 <- 01
    write-word(236f) <- call 5880 ()
    temp00 <- read-word(236f)
    if (temp00 = 0) is true then
        jump-to: LABEL 58
LABEL 01
    temp01 <- read-word(231b)
    temp02 <- read-word(2313)
    L00 <- read-word(temp01 + (temp02 * 2))
    temp03 <- read-word(231d)
    temp04 <- read-word(2313)
    L01 <- read-word(temp03 + (temp04 * 2))
    temp05 <- L01
    if (temp05 = 0) is false then
        jump-to: LABEL 03
LABEL 02
    temp06 <- L01
    push-SP: temp06
    jump-to: LABEL 0b
LABEL 03
    temp07 <- L01
    if (int16(temp07) > int16(01)) is false then
        jump-to: LABEL 08
LABEL 04
    temp08 <- read-word(231d)
    L05 <- temp08
    temp09 <- L00
    if (temp09 = 0) is false then
        jump-to: LABEL 06
LABEL 05
    L04 <- 00
    jump-to: LABEL 07
LABEL 06
    temp0a <- read-word(231b)
    L04 <- read-word(temp0a + 2)
LABEL 07
    temp0b <- L01
    push-SP: temp0b
    jump-to: LABEL 0b
LABEL 08
    temp0c <- L00
    if (int16(temp0c) > int16(01)) is false then
        jump-to: LABEL 0a
LABEL 09
    L07 <- 00
    temp0d <- read-word(231b)
    L05 <- temp0d
    temp0e <- read-word(231d)
    L04 <- read-word(temp0e + 2)
    temp0f <- L00
    push-SP: temp0f
    jump-to: LABEL 0b
LABEL 0a
    push-SP: 01
LABEL 0b
    temp10 <- pop-SP
    L02 <- temp10
    temp11 <- L04
    if (temp11 = 0) is false then
        jump-to: LABEL 0e
LABEL 0c
    temp12 <- L00
    temp13 <- (temp12 = 01)
    if (temp13) is false then
        jump-to: LABEL 0e
LABEL 0d
    temp14 <- read-word(231b)
    L04 <- read-word(temp14 + 2)
LABEL 0e
    temp15 <- read-word(2361)
    temp16 <- (temp15 = 89)
    if (temp16) is false then
        jump-to: LABEL 10
LABEL 0f
    temp17 <- read-word(2361)
    temp18 <- read-word(235d)
    L06 <- call 577c (temp17, temp18)
    jump-to: LABEL 44
LABEL 10
    temp19 <- L02
    if (temp19 = 0) is false then
        jump-to: LABEL 16
LABEL 11
    temp1a <- read-word(2357)
    temp1b <- read-byte(temp1a)
    temp1c <- (temp1b & 03)
    if (temp1c = 0) is false then
        jump-to: LABEL 13
LABEL 12
    temp1d <- read-word(2361)
    L06 <- call 577c (temp1d)
    write-word(235d) <- 00
    jump-to: LABEL 44
LABEL 13
    temp1e <- read-word(22f5)
    if (temp1e = 0) is false then
        jump-to: LABEL 15
LABEL 14
    print: "It's too dark to see."
    print: "\n"
    jump-to: LABEL 44
LABEL 15
    print: "It's not clear what you're referring to."
    print: "\n"
    L06 <- 00
    jump-to: LABEL 44
LABEL 16
    write-word(2365) <- 00
    write-word(2367) <- 00
    temp1f <- L02
    if (int16(temp1f) > int16(01)) is false then
        jump-to: LABEL 18
LABEL 17
    write-word(2367) <- 01
LABEL 18
    L09 <- 00
LABEL 19
    temp20 <- L02
    temp21 <- L03
    temp22 <- (int16(temp21) + int16(1))
    L03 <- temp22
    if (int16(temp22) > int16(temp20)) is false then
        jump-to: LABEL 25
LABEL 1a
    temp23 <- read-word(2365)
    if (int16(temp23) > int16(00)) is false then
        jump-to: LABEL 23
LABEL 1b
    print: "The "
    temp24 <- read-word(2365)
    temp25 <- L02
    temp26 <- (temp24 = temp25)
    if (temp26) is true then
        jump-to: LABEL 1d
LABEL 1c
    print: "other "
LABEL 1d
    print: "object"
    temp27 <- read-word(2365)
    temp28 <- (temp27 = 01)
    if (temp28) is true then
        jump-to: LABEL 1f
LABEL 1e
    print: "s"
LABEL 1f
    print: " that you mentioned "
    temp29 <- read-word(2365)
    temp2a <- (temp29 = 01)
    if (temp2a) is true then
        jump-to: LABEL 21
LABEL 20
    print: "are"
    jump-to: LABEL 22
LABEL 21
    print: "is"
LABEL 22
    print: "n't here."
    print: "\n"
    jump-to: LABEL 44
LABEL 23
    temp2b <- L09
    if (temp2b = 0) is false then
        jump-to: LABEL 44
LABEL 24
    print: "There's nothing here you can take."
    print: "\n"
    jump-to: LABEL 44
LABEL 25
    temp2c <- L07
    if (temp2c = 0) is true then
        jump-to: LABEL 27
LABEL 26
    temp2d <- read-word(231d)
    temp2e <- L03
    L08 <- read-word(temp2d + (temp2e * 2))
    jump-to: LABEL 28
LABEL 27
    temp2f <- read-word(231b)
    temp30 <- L03
    L08 <- read-word(temp2f + (temp30 * 2))
LABEL 28
    temp31 <- L07
    if (temp31 = 0) is true then
        jump-to: LABEL 2a
LABEL 29
    temp32 <- L08
    push-SP: temp32
    jump-to: LABEL 2b
LABEL 2a
    temp33 <- L04
    push-SP: temp33
LABEL 2b
    temp34 <- pop-SP
    write-word(235d) <- temp34
    temp35 <- L07
    if (temp35 = 0) is true then
        jump-to: LABEL 2d
LABEL 2c
    temp36 <- L04
    push-SP: temp36
    jump-to: LABEL 2e
LABEL 2d
    temp37 <- L08
    push-SP: temp37
LABEL 2e
    temp38 <- pop-SP
    write-word(235f) <- temp38
    temp39 <- L02
    if (int16(temp39) > int16(01)) is true then
        jump-to: LABEL 30
LABEL 2f
    temp3a <- read-word(2339)
    temp3b <- read-word(temp3a + c)
    temp3c <- read-word(temp3b)
    temp3d <- (temp3c = 3b7c)
    if (temp3d) is false then
        jump-to: LABEL 42
LABEL 30
    temp3e <- L08
    temp3f <- (temp3e = 0b)
    if (temp3f) is false then
        jump-to: LABEL 32
LABEL 31
    temp40 <- read-word(2365)
    write-word(2365) <- (int16(temp40) + int16(1))
    jump-to: LABEL 19
LABEL 32
    temp41 <- read-word(2361)
    temp42 <- (temp41 = 5d)
    if (temp42) is false then
        jump-to: LABEL 37
LABEL 33
    temp43 <- read-word(235f)
    if (temp43 = 0) is true then
        jump-to: LABEL 37
LABEL 34
    temp44 <- read-word(2339)
    temp45 <- read-word(temp44 + c)
    temp46 <- read-word(temp45)
    temp47 <- (temp46 = 3b7c)
    if (temp47) is false then
        jump-to: LABEL 37
LABEL 35
    temp48 <- read-word(235d)
    temp49 <- read-word(235f)
    temp4a <- (temp48 - 1)
    temp4b <- (temp4a * 9)
    temp4c <- (temp4b + 2ee)
    temp4d <- (temp4c + 4)
    temp4e <- read-byte(temp4d)
    if (temp4e = temp49) is true then
        jump-to: LABEL 37
LABEL 36
    jump-to: LABEL 19
LABEL 37
    temp4f <- read-word(2311)
    temp50 <- (temp4f = 01)
    if (temp50) is false then
        jump-to: LABEL 3e
LABEL 38
    temp51 <- read-word(2361)
    temp52 <- (temp51 = 5d)
    if (temp52) is false then
        jump-to: LABEL 3e
LABEL 39
    temp53 <- L08
    temp54 <- (temp53 - 1)
    temp55 <- (temp54 * 9)
    temp56 <- (temp55 + 2ee)
    temp57 <- (temp56 + 4)
    temp58 <- read-byte(temp57)
    temp59 <- read-word(234f)
    temp5a <- read-word(2271)
    temp5b <- (temp58 = temp59)
    temp5c <- (temp58 = temp5a)
    if (temp5b | temp5c) is true then
        jump-to: LABEL 3b
LABEL 3a
    temp5d <- L08
    temp5e <- (temp5d - 1)
    temp5f <- (temp5e * 9)
    temp60 <- (temp5f + 2ee)
    temp61 <- (temp60 + 4)
    temp62 <- read-byte(temp61)
    temp63 <- (temp62 - 1)
    temp64 <- (temp63 * 9)
    temp65 <- (temp64 + 2ee)
    temp66 <- (temp65 + 1)
    temp67 <- read-byte(temp66)
    temp68 <- (temp67 & 0020)
    temp69 <- (temp68 <> 0)
    if (temp69 = 1) is false then
        jump-to: LABEL 19
LABEL 3b
    temp6a <- L08
    temp6b <- (temp6a - 1)
    temp6c <- (temp6b * 9)
    temp6d <- (temp6c + 2ee)
    temp6e <- (temp6d + 2)
    temp6f <- read-byte(temp6e)
    temp70 <- (temp6f & 0040)
    temp71 <- (temp70 <> 0)
    if (temp71 = 1) is true then
        jump-to: LABEL 3e
LABEL 3c
    temp72 <- L08
    temp73 <- (temp72 - 1)
    temp74 <- (temp73 * 9)
    temp75 <- (temp74 + 2ee)
    temp76 <- (temp75 + 1)
    temp77 <- read-byte(temp76)
    temp78 <- (temp77 & 0004)
    temp79 <- (temp78 <> 0)
    if (temp79 = 1) is true then
        jump-to: LABEL 3e
LABEL 3d
    jump-to: LABEL 19
LABEL 3e
    temp7a <- L08
    temp7b <- (temp7a = 0c)
    if (temp7b) is false then
        jump-to: LABEL 40
LABEL 3f
    temp7c <- read-word(2347)
    temp7d <- (temp7c - 1)
    temp7e <- (temp7d * 9)
    temp7f <- (temp7e + 2ee)
    temp80 <- (temp7f + 7)
    temp81 <- read-word(temp80)
    temp82 <- read-byte(temp81)
    temp83 <- (temp81 + 1)
    print: read-text(temp83, temp82)
    jump-to: LABEL 41
LABEL 40
    temp84 <- L08
    temp85 <- (temp84 - 1)
    temp86 <- (temp85 * 9)
    temp87 <- (temp86 + 2ee)
    temp88 <- (temp87 + 7)
    temp89 <- read-word(temp88)
    temp8a <- read-byte(temp89)
    temp8b <- (temp89 + 1)
    print: read-text(temp8b, temp8a)
LABEL 41
    print: ": "
LABEL 42
    L09 <- 01
    temp8c <- read-word(2361)
    temp8d <- read-word(235d)
    temp8e <- read-word(235f)
    L06 <- call 577c (temp8c, temp8d, temp8e)
    temp8f <- L06
    temp90 <- (temp8f = 02)
    if (temp90) is false then
        jump-to: LABEL 19
LABEL 43
    jump-to: LABEL 44
LABEL 44
    temp91 <- L06
    temp92 <- (temp91 = 02)
    if (temp92) is true then
        jump-to: LABEL 52
LABEL 45
    temp93 <- read-word(234f)
    temp94 <- (temp93 - 1)
    temp95 <- (temp94 * 9)
    temp96 <- (temp95 + 2ee)
    temp97 <- (temp96 + 4)
    temp98 <- read-byte(temp97)
    temp99 <- (temp98 - 1)
    temp9a <- (temp99 * 9)
    temp9b <- (temp9a + 2ee)
    temp9c <- (temp9b + 7)
    temp9d <- read-word(temp9c)
    temp9e <- read-byte(temp9d)
    temp9f <- (temp9d + 1)
    tempa0 <- (temp9e * 2)
    tempa1 <- (temp9f + tempa0)
    tempa2 <- uint16(tempa1)
    tempa3 <- 0
LABEL 46
    tempa4 <- read-byte(tempa2)
    if ((tempa4 & 1f) <= 11) is false then
        jump-to: LABEL 48
LABEL 47
    tempa3 <- 1
    jump-to: LABEL 49
LABEL 48
    tempa5 <- read-byte(tempa2)
    tempa6 <- ((tempa2 + 1) + ((tempa5 >> 5) + 1))
    tempa2 <- uint16(tempa6)
LABEL 49
    if (tempa3 = 0) is true then
        jump-to: LABEL 46
    if ((tempa4 & 1f) = 11) is false then
        jump-to: LABEL 4e
LABEL 4a
    tempa2 <- (tempa2 + 1)
    if ((tempa4 & e0) = 0) is false then
        jump-to: LABEL 4c
LABEL 4b
    tempa7 <- read-byte(tempa2)
    jump-to: LABEL 4d
LABEL 4c
    tempa7 <- read-word(tempa2)
LABEL 4d
    jump-to: LABEL 4f
LABEL 4e
    tempa8 <- read-word(2d0)
    tempa7 <- uint16(tempa8)
LABEL 4f
    if (tempa7 = 0) is false then
        jump-to: LABEL 51
LABEL 50
    L06 <- 0
    jump-to: LABEL 52
LABEL 51
    L06 <- call (tempa7 * 2) (06)
LABEL 52
    tempa9 <- read-word(2361)
    tempaa <- (tempa9 = 08)
    tempab <- (tempa9 = 89)
    tempac <- (tempa9 = 0f)
    if ((tempaa | tempab) | tempac) is true then
        jump-to: LABEL 56
LABEL 53
    tempad <- read-word(2361)
    tempae <- (tempad = 0c)
    tempaf <- (tempad = 09)
    tempb0 <- (tempad = 07)
    if ((tempae | tempaf) | tempb0) is false then
        jump-to: LABEL 55
LABEL 54
    jump-to: LABEL 56
LABEL 55
    tempb1 <- read-word(2361)
    write-word(236d) <- tempb1
    tempb2 <- read-word(235d)
    write-word(236b) <- tempb2
    tempb3 <- read-word(235f)
    write-word(2369) <- tempb3
LABEL 56
    tempb4 <- L06
    tempb5 <- (tempb4 = 02)
    if (tempb5) is false then
        jump-to: LABEL 59
LABEL 57
    write-word(2349) <- 00
    jump-to: LABEL 59
LABEL 58
    write-word(2349) <- 00
LABEL 59
    tempb6 <- read-word(236f)
    if (tempb6 = 0) is true then
        jump-to: LABEL 00
LABEL 5a
    tempb7 <- read-word(2361)
    tempb8 <- (tempb7 = 02)
    tempb9 <- (tempb7 = 01)
    tempba <- (tempb7 = 6f)
    if ((tempb8 | tempb9) | tempba) is true then
        jump-to: LABEL 00
LABEL 5b
    tempbb <- read-word(2361)
    tempbc <- (tempbb = 0c)
    tempbd <- (tempbb = 08)
    tempbe <- (tempbb = 00)
    if ((tempbc | tempbd) | tempbe) is true then
        jump-to: LABEL 00
LABEL 5c
    tempbf <- read-word(2361)
    tempc0 <- (tempbf = 09)
    tempc1 <- (tempbf = 06)
    tempc2 <- (tempbf = 05)
    if ((tempc0 | tempc1) | tempc2) is true then
        jump-to: LABEL 00
LABEL 5d
    tempc3 <- read-word(2361)
    tempc4 <- (tempc3 = 07)
    tempc5 <- (tempc3 = 0b)
    tempc6 <- (tempc3 = 0a)
    if ((tempc4 | tempc5) | tempc6) is false then
        jump-to: LABEL 5f
LABEL 5e
    jump-to: LABEL 00
LABEL 5f
    L06 <- call 54c4 ()
    jump-to: LABEL 00
]]>

        TestBinder(Zork1, &H552A, expected)
    End Sub

#End Region
#Region "Zork1_6A52"

#Region "ZCode"
    ' 6a5d:  a2 01 01 40             GET_CHILD       L00 -> L00 [FALSE] RFALSE
    ' 6a61:  41 03 02 da             JE              L02,#02 [TRUE] 6a7d
    ' 6a65:  52 01 12 00             GET_PROP_ADDR   L00,#12 -> -(SP)
    ' 6a69:  a0 00 d3                JZ              (SP)+ [TRUE] 6a7d
    ' 6a6c:  e0 2b 36 8e 01 02 00    CALL            6d1c (L00,L01) -> -(SP)
    ' 6a73:  a0 00 c9                JZ              (SP)+ [TRUE] 6a7d
    ' 6a76:  e0 2b 35 5d 01 02 00    CALL            6aba (L00,L01) -> -(SP)
    ' 6a7d:  41 03 00 4a             JE              L02,#00 [FALSE] 6a89
    ' 6a81:  4a 01 08 c6             TEST_ATTR       L00,#08 [TRUE] 6a89
    ' 6a85:  4a 01 0a 6d             TEST_ATTR       L00,#0a [FALSE] 6ab4
    ' 6a89:  a2 01 05 69             GET_CHILD       L00 -> L04 [FALSE] 6ab4
    ' 6a8d:  4a 01 0b c6             TEST_ATTR       L00,#0b [TRUE] 6a95
    ' 6a91:  4a 01 0c 61             TEST_ATTR       L00,#0c [FALSE] 6ab4
    ' 6a95:  4a 01 0a 48             TEST_ATTR       L00,#0a [FALSE] 6a9f
    ' 6a99:  e8 7f 01                PUSH            #01
    ' 6a9c:  8c 00 0f                JUMP            6aac
    ' 6a9f:  4a 01 08 48             TEST_ATTR       L00,#08 [FALSE] 6aa9
    ' 6aa3:  e8 7f 01                PUSH            #01
    ' 6aa6:  8c 00 05                JUMP            6aac
    ' 6aa9:  e8 7f 00                PUSH            #00
    ' 6aac:  e0 2a 35 29 01 02 00 04 CALL            6a52 (L00,L01,(SP)+) -> L03
    ' 6ab4:  a1 01 01 bf aa          GET_SIBLING     L00 -> L00 [TRUE] 6a61
    ' 6ab9:  b0                      RTRUE
#End Region

    <Fact>
    Sub Zork1_6A52()
        Dim expected =
<![CDATA[
# temps: 94

LABEL 00
    temp00 <- L00
    temp01 <- (temp00 - 1)
    temp02 <- (temp01 * 9)
    temp03 <- (temp02 + 2ee)
    temp04 <- (temp03 + 6)
    temp05 <- read-byte(temp04)
    L00 <- temp05
    if (temp05 <> 0) is false then
        return: 0
LABEL 01
    temp06 <- L02
    temp07 <- (temp06 = 02)
    if (temp07) is true then
        jump-to: LABEL 0c
LABEL 02
    temp08 <- L00
    temp09 <- (temp08 - 1)
    temp0a <- (temp09 * 9)
    temp0b <- (temp0a + 2ee)
    temp0c <- (temp0b + 7)
    temp0d <- read-word(temp0c)
    temp0e <- read-byte(temp0d)
    temp0f <- (temp0d + 1)
    temp10 <- (temp0e * 2)
    temp11 <- (temp0f + temp10)
    temp12 <- uint16(temp11)
    temp13 <- 0
LABEL 03
    temp14 <- read-byte(temp12)
    if ((temp14 & 1f) <= 12) is false then
        jump-to: LABEL 05
LABEL 04
    temp13 <- 1
    jump-to: LABEL 06
LABEL 05
    temp15 <- read-byte(temp12)
    temp16 <- ((temp12 + 1) + ((temp15 >> 5) + 1))
    temp12 <- uint16(temp16)
LABEL 06
    if (temp13 = 0) is true then
        jump-to: LABEL 03
    if ((temp14 & 1f) = 12) is false then
        jump-to: LABEL 08
LABEL 07
    push-SP: (temp12 + 1)
    jump-to: LABEL 09
LABEL 08
    push-SP: 0
LABEL 09
    temp17 <- pop-SP
    if (temp17 = 0) is true then
        jump-to: LABEL 0c
LABEL 0a
    temp18 <- L00
    temp19 <- L01
    temp1a <- call 6d1c (temp18, temp19)
    if (temp1a = 0) is true then
        jump-to: LABEL 0c
LABEL 0b
    temp1b <- L00
    temp1c <- L01
    push-SP: call 6aba (temp1b, temp1c)
LABEL 0c
    temp1d <- L02
    temp1e <- (temp1d = 00)
    if (temp1e) is false then
        jump-to: LABEL 0f
LABEL 0d
    temp1f <- L00
    temp20 <- (temp1f - 1)
    temp21 <- (temp20 * 9)
    temp22 <- (temp21 + 2ee)
    temp23 <- (temp22 + 1)
    temp24 <- read-byte(temp23)
    temp25 <- (temp24 & 0080)
    temp26 <- (temp25 <> 0)
    if (temp26 = 1) is true then
        jump-to: LABEL 0f
LABEL 0e
    temp27 <- L00
    temp28 <- (temp27 - 1)
    temp29 <- (temp28 * 9)
    temp2a <- (temp29 + 2ee)
    temp2b <- (temp2a + 1)
    temp2c <- read-byte(temp2b)
    temp2d <- (temp2c & 0020)
    temp2e <- (temp2d <> 0)
    if (temp2e = 1) is false then
        jump-to: LABEL 18
LABEL 0f
    temp2f <- L00
    temp30 <- (temp2f - 1)
    temp31 <- (temp30 * 9)
    temp32 <- (temp31 + 2ee)
    temp33 <- (temp32 + 6)
    temp34 <- read-byte(temp33)
    L04 <- temp34
    if (temp34 <> 0) is false then
        jump-to: LABEL 18
LABEL 10
    temp35 <- L00
    temp36 <- (temp35 - 1)
    temp37 <- (temp36 * 9)
    temp38 <- (temp37 + 2ee)
    temp39 <- (temp38 + 1)
    temp3a <- read-byte(temp39)
    temp3b <- (temp3a & 0010)
    temp3c <- (temp3b <> 0)
    if (temp3c = 1) is true then
        jump-to: LABEL 12
LABEL 11
    temp3d <- L00
    temp3e <- (temp3d - 1)
    temp3f <- (temp3e * 9)
    temp40 <- (temp3f + 2ee)
    temp41 <- (temp40 + 1)
    temp42 <- read-byte(temp41)
    temp43 <- (temp42 & 0008)
    temp44 <- (temp43 <> 0)
    if (temp44 = 1) is false then
        jump-to: LABEL 18
LABEL 12
    temp45 <- L00
    temp46 <- (temp45 - 1)
    temp47 <- (temp46 * 9)
    temp48 <- (temp47 + 2ee)
    temp49 <- (temp48 + 1)
    temp4a <- read-byte(temp49)
    temp4b <- (temp4a & 0020)
    temp4c <- (temp4b <> 0)
    if (temp4c = 1) is false then
        jump-to: LABEL 14
LABEL 13
    push-SP: 01
    jump-to: LABEL 17
LABEL 14
    temp4d <- L00
    temp4e <- (temp4d - 1)
    temp4f <- (temp4e * 9)
    temp50 <- (temp4f + 2ee)
    temp51 <- (temp50 + 1)
    temp52 <- read-byte(temp51)
    temp53 <- (temp52 & 0080)
    temp54 <- (temp53 <> 0)
    if (temp54 = 1) is false then
        jump-to: LABEL 16
LABEL 15
    push-SP: 01
    jump-to: LABEL 17
LABEL 16
    push-SP: 00
LABEL 17
    temp55 <- L00
    temp56 <- L01
    temp57 <- pop-SP
    L03 <- call 6a52 (temp55, temp56, temp57)
LABEL 18
    temp58 <- L00
    temp59 <- (temp58 - 1)
    temp5a <- (temp59 * 9)
    temp5b <- (temp5a + 2ee)
    temp5c <- (temp5b + 5)
    temp5d <- read-byte(temp5c)
    L00 <- temp5d
    if (temp5d <> 0) is true then
        jump-to: LABEL 01
LABEL 19
    return: 1
]]>

        TestBinder(Zork1, &H6A52, expected)
    End Sub

#End Region
#Region "Zork1_8C9A"

#Region "ZCode"
    ' 8ca3:  a0 01 c8                JZ              L00 [TRUE] 8cac
    ' 8ca6:  e8 bf 01                PUSH            L00
    ' 8ca9:  8c 00 05                JUMP            8caf
    ' 8cac:  e8 bf 57                PUSH            G47
    ' 8caf:  e9 7f 02                PULL            L01
    ' 8cb2:  a0 52 71                JZ              G42 [FALSE] 8ce4
    ' 8cb5:  b2 ...                  PRINT           "It is pitch black."
    ' 8cc2:  a0 51 59                JZ              G41 [FALSE] 8cdc
    ' 8cc5:  b2 ...                  PRINT           " You are likely to be eaten by a grue."
    ' 8cdc:  bb                      NEW_LINE
    ' 8cdd:  e0 3f 28 68 00          CALL            50d0 -> -(SP)
    ' 8ce2:  9b 00                   RET             #00
    ' 8ce4:  4a 10 03 c8             TEST_ATTR       G00,#03 [TRUE] 8cee
    ' 8ce8:  4b 10 03                SET_ATTR        G00,#03
    ' 8ceb:  0d 02 01                STORE           L01,#01
    ' 8cee:  4a 10 05 45             TEST_ATTR       G00,#05 [FALSE] 8cf5
    ' 8cf2:  4c 10 03                CLEAR_ATTR      G00,#03
    ' 8cf5:  46 10 52 53             JIN             G00,#52 [FALSE] 8d0a
    ' 8cf9:  aa 10                   PRINT_OBJ       G00
    ' 8cfb:  a3 7f 04                GET_PARENT      G6f -> L03
    ' 8cfe:  4a 04 1b 49             TEST_ATTR       L03,#1b [FALSE] 8d09
    ' 8d02:  b2 ...                  PRINT           ", in the "
    ' 8d07:  aa 04                   PRINT_OBJ       L03
    ' 8d09:  bb                      NEW_LINE        
    ' 8d0a:  a0 01 45                JZ              L00 [FALSE] 8d10
    ' 8d0d:  a0 56 41                JZ              G46 [FALSE] RTRUE
    ' 8d10:  a3 7f 04                GET_PARENT      G6f -> L03
    ' 8d13:  a0 02 ce                JZ              L01 [TRUE] 8d22
    ' 8d16:  51 10 11 00             GET_PROP        G00,#11 -> -(SP)
    ' 8d1a:  e0 9f 00 03 00          CALL            (SP)+ (#03) -> -(SP)
    ' 8d1f:  a0 00 41                JZ              (SP)+ [FALSE] RTRUE
    ' 8d22:  a0 02 cf                JZ              L01 [TRUE] 8d32
    ' 8d25:  51 10 0b 03             GET_PROP        G00,#0b -> L02
    ' 8d29:  a0 03 c8                JZ              L02 [TRUE] 8d32
    ' 8d2c:  ad 03                   PRINT_PADDR     L02
    ' 8d2e:  bb                      NEW_LINE        
    ' 8d2f:  8c 00 0b                JUMP            8d3b
    ' 8d32:  51 10 11 00             GET_PROP        G00,#11 -> -(SP)
    ' 8d36:  e0 9f 00 04 00          CALL            (SP)+ (#04) -> -(SP)
    ' 8d3b:  61 10 04 c1             JE              G00,L03 [TRUE] RTRUE
    ' 8d3f:  4a 04 1b 41             TEST_ATTR       L03,#1b [FALSE] RTRUE
    ' 8d43:  51 04 11 00             GET_PROP        L03,#11 -> -(SP)
    ' 8d47:  e0 9f 00 03 00          CALL            (SP)+ (#03) -> -(SP)
    ' 8d4c:  b0                      RTRUE
#End Region

    <Fact>
    Sub Zork1_8C9A()
        Dim expected =
<![CDATA[
# temps: 158

LABEL 00
    temp00 <- L00
    if (temp00 = 0) is true then
        jump-to: LABEL 02
LABEL 01
    temp01 <- L00
    push-SP: temp01
    jump-to: LABEL 03
LABEL 02
    temp02 <- read-word(22ff)
    push-SP: temp02
LABEL 03
    temp03 <- pop-SP
    L01 <- temp03
    temp04 <- read-word(22f5)
    if (temp04 = 0) is false then
        jump-to: LABEL 07
LABEL 04
    print: "It is pitch black."
    temp05 <- read-word(22f3)
    if (temp05 = 0) is false then
        jump-to: LABEL 06
LABEL 05
    print: " You are likely to be eaten by a grue."
LABEL 06
    print: "\n"
    push-SP: call 50d0 ()
    return: 00
LABEL 07
    temp06 <- read-word(2271)
    temp07 <- (temp06 - 1)
    temp08 <- (temp07 * 9)
    temp09 <- (temp08 + 2ee)
    temp0a <- read-byte(temp09)
    temp0b <- (temp0a & 0010)
    temp0c <- (temp0b <> 0)
    if (temp0c = 1) is true then
        jump-to: LABEL 09
LABEL 08
    temp0d <- read-word(2271)
    temp0e <- (temp0d - 1)
    temp0f <- (temp0e * 9)
    temp10 <- (temp0f + 2ee)
    temp11 <- read-byte(temp10)
    write-byte(temp10) <- byte(temp11 | 0010)
    L01 <- 01
LABEL 09
    temp12 <- read-word(2271)
    temp13 <- (temp12 - 1)
    temp14 <- (temp13 * 9)
    temp15 <- (temp14 + 2ee)
    temp16 <- read-byte(temp15)
    temp17 <- (temp16 & 0004)
    temp18 <- (temp17 <> 0)
    if (temp18 = 1) is false then
        jump-to: LABEL 0b
LABEL 0a
    temp19 <- read-word(2271)
    temp1a <- (temp19 - 1)
    temp1b <- (temp1a * 9)
    temp1c <- (temp1b + 2ee)
    temp1d <- read-byte(temp1c)
    write-byte(temp1c) <- byte(temp1d & not 0010)
LABEL 0b
    temp1e <- read-word(2271)
    temp1f <- (temp1e - 1)
    temp20 <- (temp1f * 9)
    temp21 <- (temp20 + 2ee)
    temp22 <- (temp21 + 4)
    temp23 <- read-byte(temp22)
    if (temp23 = 52) is false then
        jump-to: LABEL 0f
LABEL 0c
    temp24 <- read-word(2271)
    temp25 <- (temp24 - 1)
    temp26 <- (temp25 * 9)
    temp27 <- (temp26 + 2ee)
    temp28 <- (temp27 + 7)
    temp29 <- read-word(temp28)
    temp2a <- read-byte(temp29)
    temp2b <- (temp29 + 1)
    print: read-text(temp2b, temp2a)
    temp2c <- read-word(234f)
    temp2d <- (temp2c - 1)
    temp2e <- (temp2d * 9)
    temp2f <- (temp2e + 2ee)
    temp30 <- (temp2f + 4)
    temp31 <- read-byte(temp30)
    L03 <- temp31
    temp32 <- L03
    temp33 <- (temp32 - 1)
    temp34 <- (temp33 * 9)
    temp35 <- (temp34 + 2ee)
    temp36 <- (temp35 + 3)
    temp37 <- read-byte(temp36)
    temp38 <- (temp37 & 0010)
    temp39 <- (temp38 <> 0)
    if (temp39 = 1) is false then
        jump-to: LABEL 0e
LABEL 0d
    print: ", in the "
    temp3a <- L03
    temp3b <- (temp3a - 1)
    temp3c <- (temp3b * 9)
    temp3d <- (temp3c + 2ee)
    temp3e <- (temp3d + 7)
    temp3f <- read-word(temp3e)
    temp40 <- read-byte(temp3f)
    temp41 <- (temp3f + 1)
    print: read-text(temp41, temp40)
LABEL 0e
    print: "\n"
LABEL 0f
    temp42 <- L00
    if (temp42 = 0) is false then
        jump-to: LABEL 11
LABEL 10
    temp43 <- read-word(22fd)
    if (temp43 = 0) is false then
        return: 1
LABEL 11
    temp44 <- read-word(234f)
    temp45 <- (temp44 - 1)
    temp46 <- (temp45 * 9)
    temp47 <- (temp46 + 2ee)
    temp48 <- (temp47 + 4)
    temp49 <- read-byte(temp48)
    L03 <- temp49
    temp4a <- L01
    if (temp4a = 0) is true then
        jump-to: LABEL 20
LABEL 12
    temp4b <- read-word(2271)
    temp4c <- (temp4b - 1)
    temp4d <- (temp4c * 9)
    temp4e <- (temp4d + 2ee)
    temp4f <- (temp4e + 7)
    temp50 <- read-word(temp4f)
    temp51 <- read-byte(temp50)
    temp52 <- (temp50 + 1)
    temp53 <- (temp51 * 2)
    temp54 <- (temp52 + temp53)
    temp55 <- uint16(temp54)
    temp56 <- 0
LABEL 13
    temp57 <- read-byte(temp55)
    if ((temp57 & 1f) <= 11) is false then
        jump-to: LABEL 15
LABEL 14
    temp56 <- 1
    jump-to: LABEL 16
LABEL 15
    temp58 <- read-byte(temp55)
    temp59 <- ((temp55 + 1) + ((temp58 >> 5) + 1))
    temp55 <- uint16(temp59)
LABEL 16
    if (temp56 = 0) is true then
        jump-to: LABEL 13
    if ((temp57 & 1f) = 11) is false then
        jump-to: LABEL 1b
LABEL 17
    temp55 <- (temp55 + 1)
    if ((temp57 & e0) = 0) is false then
        jump-to: LABEL 19
LABEL 18
    temp5a <- read-byte(temp55)
    jump-to: LABEL 1a
LABEL 19
    temp5a <- read-word(temp55)
LABEL 1a
    jump-to: LABEL 1c
LABEL 1b
    temp5b <- read-word(2d0)
    temp5a <- uint16(temp5b)
LABEL 1c
    if (temp5a = 0) is false then
        jump-to: LABEL 1e
LABEL 1d
    push-SP: 0
    jump-to: LABEL 1f
LABEL 1e
    push-SP: call (temp5a * 2) (03)
LABEL 1f
    temp5c <- pop-SP
    if (temp5c = 0) is false then
        return: 1
LABEL 20
    temp5d <- L01
    if (temp5d = 0) is true then
        jump-to: LABEL 2d
LABEL 21
    temp5e <- read-word(2271)
    temp5f <- (temp5e - 1)
    temp60 <- (temp5f * 9)
    temp61 <- (temp60 + 2ee)
    temp62 <- (temp61 + 7)
    temp63 <- read-word(temp62)
    temp64 <- read-byte(temp63)
    temp65 <- (temp63 + 1)
    temp66 <- (temp64 * 2)
    temp67 <- (temp65 + temp66)
    temp68 <- uint16(temp67)
    temp69 <- 0
LABEL 22
    temp6a <- read-byte(temp68)
    if ((temp6a & 1f) <= 0b) is false then
        jump-to: LABEL 24
LABEL 23
    temp69 <- 1
    jump-to: LABEL 25
LABEL 24
    temp6b <- read-byte(temp68)
    temp6c <- ((temp68 + 1) + ((temp6b >> 5) + 1))
    temp68 <- uint16(temp6c)
LABEL 25
    if (temp69 = 0) is true then
        jump-to: LABEL 22
    if ((temp6a & 1f) = 0b) is false then
        jump-to: LABEL 2a
LABEL 26
    temp68 <- (temp68 + 1)
    if ((temp6a & e0) = 0) is false then
        jump-to: LABEL 28
LABEL 27
    temp6d <- read-byte(temp68)
    jump-to: LABEL 29
LABEL 28
    temp6d <- read-word(temp68)
LABEL 29
    jump-to: LABEL 2b
LABEL 2a
    temp6e <- read-word(2c4)
    temp6d <- uint16(temp6e)
LABEL 2b
    L02 <- temp6d
    temp6f <- L02
    if (temp6f = 0) is true then
        jump-to: LABEL 2d
LABEL 2c
    temp70 <- L02
    print: read-text(temp70 * 2)
    print: "\n"
    jump-to: LABEL 3a
LABEL 2d
    temp71 <- read-word(2271)
    temp72 <- (temp71 - 1)
    temp73 <- (temp72 * 9)
    temp74 <- (temp73 + 2ee)
    temp75 <- (temp74 + 7)
    temp76 <- read-word(temp75)
    temp77 <- read-byte(temp76)
    temp78 <- (temp76 + 1)
    temp79 <- (temp77 * 2)
    temp7a <- (temp78 + temp79)
    temp7b <- uint16(temp7a)
    temp7c <- 0
LABEL 2e
    temp7d <- read-byte(temp7b)
    if ((temp7d & 1f) <= 11) is false then
        jump-to: LABEL 30
LABEL 2f
    temp7c <- 1
    jump-to: LABEL 31
LABEL 30
    temp7e <- read-byte(temp7b)
    temp7f <- ((temp7b + 1) + ((temp7e >> 5) + 1))
    temp7b <- uint16(temp7f)
LABEL 31
    if (temp7c = 0) is true then
        jump-to: LABEL 2e
    if ((temp7d & 1f) = 11) is false then
        jump-to: LABEL 36
LABEL 32
    temp7b <- (temp7b + 1)
    if ((temp7d & e0) = 0) is false then
        jump-to: LABEL 34
LABEL 33
    temp80 <- read-byte(temp7b)
    jump-to: LABEL 35
LABEL 34
    temp80 <- read-word(temp7b)
LABEL 35
    jump-to: LABEL 37
LABEL 36
    temp81 <- read-word(2d0)
    temp80 <- uint16(temp81)
LABEL 37
    if (temp80 = 0) is false then
        jump-to: LABEL 39
LABEL 38
    push-SP: 0
    jump-to: LABEL 3a
LABEL 39
    push-SP: call (temp80 * 2) (04)
LABEL 3a
    temp82 <- read-word(2271)
    temp83 <- L03
    temp84 <- (temp82 = temp83)
    if (temp84) is true then
        return: 1
LABEL 3b
    temp85 <- L03
    temp86 <- (temp85 - 1)
    temp87 <- (temp86 * 9)
    temp88 <- (temp87 + 2ee)
    temp89 <- (temp88 + 3)
    temp8a <- read-byte(temp89)
    temp8b <- (temp8a & 0010)
    temp8c <- (temp8b <> 0)
    if (temp8c = 1) is false then
        return: 1
LABEL 3c
    temp8d <- L03
    temp8e <- (temp8d - 1)
    temp8f <- (temp8e * 9)
    temp90 <- (temp8f + 2ee)
    temp91 <- (temp90 + 7)
    temp92 <- read-word(temp91)
    temp93 <- read-byte(temp92)
    temp94 <- (temp92 + 1)
    temp95 <- (temp93 * 2)
    temp96 <- (temp94 + temp95)
    temp97 <- uint16(temp96)
    temp98 <- 0
LABEL 3d
    temp99 <- read-byte(temp97)
    if ((temp99 & 1f) <= 11) is false then
        jump-to: LABEL 3f
LABEL 3e
    temp98 <- 1
    jump-to: LABEL 40
LABEL 3f
    temp9a <- read-byte(temp97)
    temp9b <- ((temp97 + 1) + ((temp9a >> 5) + 1))
    temp97 <- uint16(temp9b)
LABEL 40
    if (temp98 = 0) is true then
        jump-to: LABEL 3d
    if ((temp99 & 1f) = 11) is false then
        jump-to: LABEL 45
LABEL 41
    temp97 <- (temp97 + 1)
    if ((temp99 & e0) = 0) is false then
        jump-to: LABEL 43
LABEL 42
    temp9c <- read-byte(temp97)
    jump-to: LABEL 44
LABEL 43
    temp9c <- read-word(temp97)
LABEL 44
    jump-to: LABEL 46
LABEL 45
    temp9d <- read-word(2d0)
    temp9c <- uint16(temp9d)
LABEL 46
    if (temp9c = 0) is false then
        jump-to: LABEL 48
LABEL 47
    push-SP: 0
    jump-to: LABEL 49
LABEL 48
    push-SP: call (temp9c * 2) (03)
LABEL 49
    return: 1
]]>

        TestBinder(Zork1, &H8C9A, expected)
    End Sub

#End Region
#Region "Zork1_101E0"

#Region "ZCode"
    '101eb:  93 72 01                GET_PARENT      "thief" -> L00
    '101ee:  0a 72 07 c8             TEST_ATTR       "thief",#07 [TRUE] 101f8
    '101f2:  e8 7f 01                PUSH            #01
    '101f5:  8c 00 05                JUMP            101fb
    '101f8:  e8 7f 00                PUSH            #00
    '101fb:  2d 03 00                STORE           L02,(SP)+
    '101fe:  a0 03 c5                JZ              L02 [TRUE] 10204
    '10201:  93 72 01                GET_PARENT      "thief" -> L00
    '10204:  41 01 be 5a             JE              L00,#be [FALSE] 10220
    '10208:  61 01 10 d6             JE              L00,G00 [TRUE] 10220
    '1020c:  a0 03 ca                JZ              L02 [TRUE] 10217
    '1020f:  e0 3f 69 69 00          CALL            d2d2 -> -(SP)
    '10214:  0d 03 00                STORE           L02,#00
    '10217:  e0 1f 69 77 be 00       CALL            d2ee (#be) -> -(SP)
    '1021d:  8c 00 56                JUMP            10274
    '10220:  61 01 10 5e             JE              L00,G00 [FALSE] 10240
    '10224:  4a 01 14 da             TEST_ATTR       L00,#14 [TRUE] 10240
    '10228:  26 d9 10 d6             JIN             "troll",G00 [TRUE] 10240
    '1022c:  e0 2f 67 47 03 00       CALL            ce8e (L02) -> -(SP)
    '10232:  a0 00 41                JZ              (SP)+ [FALSE] RTRUE
    '10235:  0a 72 07 00 3c          TEST_ATTR       "thief",#07 [FALSE] 10274
    '1023a:  0d 03 00                STORE           L02,#00
    '1023d:  8c 00 36                JUMP            10274
    '10240:  26 72 01 4c             JIN             "thief",L00 [FALSE] 1024e
    '10244:  0a 72 07 c8             TEST_ATTR       "thief",#07 [TRUE] 1024e
    '10248:  0b 72 07                SET_ATTR        "thief",#07
    '1024b:  0d 03 00                STORE           L02,#00
    '1024e:  4a 01 03 64             TEST_ATTR       L00,#03 [FALSE] 10274
    '10252:  e0 25 81 dc 01 72 4b 00 CALL            103b8 (L00,#72,#4b) -> -(SP)
    '1025a:  4a 01 05 4f             TEST_ATTR       L00,#05 [FALSE] 1026b
    '1025e:  4a 10 05 4b             TEST_ATTR       G00,#05 [FALSE] 1026b
    '10262:  e0 2f 69 96 01 00       CALL            d32c (L00) -> -(SP)
    '10268:  8c 00 08                JUMP            10271
    '1026b:  e0 2f 81 a6 01 00       CALL            1034c (L00) -> -(SP)
    '10271:  2d 05 00                STORE           L04,(SP)+
    '10274:  a0 04 48                JZ              L03 [FALSE] 1027d
    '10277:  e8 7f 01                PUSH            #01
    '1027a:  8c 00 05                JUMP            10280
    '1027d:  e8 7f 00                PUSH            #00
    '10280:  2d 04 00                STORE           L03,(SP)+
    '10283:  a0 04 f1                JZ              L03 [TRUE] 102b5
    '10286:  a0 03 6e                JZ              L02 [FALSE] 102b5
    '10289:  e0 3f 81 9e 00          CALL            1033c -> -(SP)
    '1028e:  a0 01 c9                JZ              L00 [TRUE] 10298
    '10291:  a1 01 01 45             GET_SIBLING     L00 -> L00 [FALSE] 10298
    '10295:  8c 00 06                JUMP            1029c
    '10298:  92 52 01 c2             GET_CHILD       #52 -> L00 [TRUE] 1029c
    '1029c:  4a 01 09 bf ef          TEST_ATTR       L00,#09 [TRUE] 1028e
    '102a1:  4a 01 06 3f ea          TEST_ATTR       L00,#06 [FALSE] 1028e
    '102a6:  2e 72 01                INSERT_OBJ      "thief",L00
    '102a9:  0c 72 02                CLEAR_ATTR      "thief",#02
    '102ac:  0b 72 07                SET_ATTR        "thief",#07
    '102af:  0d 2f 00                STORE           G1f,#00
    '102b2:  8c ff 3b                JUMP            101ee
    '102b5:  41 01 be ca             JE              L00,#be [TRUE] 102c1
    '102b9:  e0 2f 81 62 01 00       CALL            102c4 (L00) -> -(SP)
    '102bf:  ab 05                   RET             L04
    '102c1:  ab 05                   RET             L04
#End Region

    <Fact>
    Sub Zork1_101E0()
        Dim expected =
<![CDATA[
# temps: 129

LABEL 00
    temp00 <- read-byte(6eb)
    L00 <- temp00
LABEL 01
    temp01 <- read-byte(6e7)
    temp02 <- (temp01 & 0001)
    temp03 <- (temp02 <> 0)
    if (temp03 = 1) is true then
        jump-to: LABEL 03
LABEL 02
    push-SP: 01
    jump-to: LABEL 04
LABEL 03
    push-SP: 00
LABEL 04
    temp04 <- pop-SP
    L02 <- temp04
    temp05 <- L02
    if (temp05 = 0) is true then
        jump-to: LABEL 06
LABEL 05
    temp06 <- read-byte(6eb)
    L00 <- temp06
LABEL 06
    temp07 <- L00
    temp08 <- (temp07 = be)
    if (temp08) is false then
        jump-to: LABEL 0b
LABEL 07
    temp09 <- L00
    temp0a <- read-word(2271)
    temp0b <- (temp09 = temp0a)
    if (temp0b) is true then
        jump-to: LABEL 0b
LABEL 08
    temp0c <- L02
    if (temp0c = 0) is true then
        jump-to: LABEL 0a
LABEL 09
    push-SP: call d2d2 ()
    L02 <- 00
LABEL 0a
    push-SP: call d2ee (be)
    jump-to: LABEL 1a
LABEL 0b
    temp0d <- L00
    temp0e <- read-word(2271)
    temp0f <- (temp0d = temp0e)
    if (temp0f) is false then
        jump-to: LABEL 11
LABEL 0c
    temp10 <- L00
    temp11 <- (temp10 - 1)
    temp12 <- (temp11 * 9)
    temp13 <- (temp12 + 2ee)
    temp14 <- (temp13 + 2)
    temp15 <- read-byte(temp14)
    temp16 <- (temp15 & 0008)
    temp17 <- (temp16 <> 0)
    if (temp17 = 1) is true then
        jump-to: LABEL 11
LABEL 0d
    temp18 <- read-word(2271)
    temp19 <- read-byte(a8a)
    if (temp19 = temp18) is true then
        jump-to: LABEL 11
LABEL 0e
    temp1a <- L02
    temp1b <- call ce8e (temp1a)
    if (temp1b = 0) is false then
        return: 1
LABEL 0f
    temp1c <- read-byte(6e7)
    temp1d <- (temp1c & 0001)
    temp1e <- (temp1d <> 0)
    if (temp1e = 1) is false then
        jump-to: LABEL 1a
LABEL 10
    L02 <- 00
    jump-to: LABEL 1a
LABEL 11
    temp1f <- L00
    temp20 <- read-byte(6eb)
    if (temp20 = temp1f) is false then
        jump-to: LABEL 14
LABEL 12
    temp21 <- read-byte(6e7)
    temp22 <- (temp21 & 0001)
    temp23 <- (temp22 <> 0)
    if (temp23 = 1) is true then
        jump-to: LABEL 14
LABEL 13
    temp24 <- read-byte(6e7)
    write-byte(6e7) <- byte(temp24 | 0001)
    L02 <- 00
LABEL 14
    temp25 <- L00
    temp26 <- (temp25 - 1)
    temp27 <- (temp26 * 9)
    temp28 <- (temp27 + 2ee)
    temp29 <- read-byte(temp28)
    temp2a <- (temp29 & 0010)
    temp2b <- (temp2a <> 0)
    if (temp2b = 1) is false then
        jump-to: LABEL 1a
LABEL 15
    temp2c <- L00
    push-SP: call 103b8 (temp2c, 72, 4b)
    temp2d <- L00
    temp2e <- (temp2d - 1)
    temp2f <- (temp2e * 9)
    temp30 <- (temp2f + 2ee)
    temp31 <- read-byte(temp30)
    temp32 <- (temp31 & 0004)
    temp33 <- (temp32 <> 0)
    if (temp33 = 1) is false then
        jump-to: LABEL 18
LABEL 16
    temp34 <- read-word(2271)
    temp35 <- (temp34 - 1)
    temp36 <- (temp35 * 9)
    temp37 <- (temp36 + 2ee)
    temp38 <- read-byte(temp37)
    temp39 <- (temp38 & 0004)
    temp3a <- (temp39 <> 0)
    if (temp3a = 1) is false then
        jump-to: LABEL 18
LABEL 17
    temp3b <- L00
    push-SP: call d32c (temp3b)
    jump-to: LABEL 19
LABEL 18
    temp3c <- L00
    push-SP: call 1034c (temp3c)
LABEL 19
    temp3d <- pop-SP
    L04 <- temp3d
LABEL 1a
    temp3e <- L03
    if (temp3e = 0) is false then
        jump-to: LABEL 1c
LABEL 1b
    push-SP: 01
    jump-to: LABEL 1d
LABEL 1c
    push-SP: 00
LABEL 1d
    temp3f <- pop-SP
    L03 <- temp3f
    temp40 <- L03
    if (temp40 = 0) is true then
        jump-to: LABEL 36
LABEL 1e
    temp41 <- L02
    if (temp41 = 0) is false then
        jump-to: LABEL 36
LABEL 1f
    push-SP: call 1033c ()
LABEL 20
    temp42 <- L00
    if (temp42 = 0) is true then
        jump-to: LABEL 23
LABEL 21
    temp43 <- L00
    temp44 <- (temp43 - 1)
    temp45 <- (temp44 * 9)
    temp46 <- (temp45 + 2ee)
    temp47 <- (temp46 + 5)
    temp48 <- read-byte(temp47)
    L00 <- temp48
    if (temp48 <> 0) is false then
        jump-to: LABEL 23
LABEL 22
    jump-to: LABEL 24
LABEL 23
    temp49 <- read-byte(5cd)
    L00 <- temp49
    if (temp49 <> 0) is true then
        jump-to: LABEL 24
LABEL 24
    temp4a <- L00
    temp4b <- (temp4a - 1)
    temp4c <- (temp4b * 9)
    temp4d <- (temp4c + 2ee)
    temp4e <- (temp4d + 1)
    temp4f <- read-byte(temp4e)
    temp50 <- (temp4f & 0040)
    temp51 <- (temp50 <> 0)
    if (temp51 = 1) is true then
        jump-to: LABEL 20
LABEL 25
    temp52 <- L00
    temp53 <- (temp52 - 1)
    temp54 <- (temp53 * 9)
    temp55 <- (temp54 + 2ee)
    temp56 <- read-byte(temp55)
    temp57 <- (temp56 & 0002)
    temp58 <- (temp57 <> 0)
    if (temp58 = 1) is false then
        jump-to: LABEL 20
LABEL 26
    temp59 <- L00
    temp5a <- 0
    temp5b <- read-byte(6ec)
    temp5c <- read-byte(6eb)
    if (temp5c = 0) is false then
        jump-to: LABEL 28
LABEL 27
    temp5d <- 0
    jump-to: LABEL 29
LABEL 28
    temp5e <- (temp5c - 1)
    temp5f <- (temp5e * 9)
    temp60 <- (temp5f + 2ee)
    temp61 <- (temp60 + 6)
    temp62 <- read-byte(temp61)
    temp5d <- temp62
LABEL 29
    if (temp5d <> 72) is false then
        jump-to: LABEL 2f
LABEL 2a
    temp63 <- temp5d
LABEL 2b
    temp64 <- (temp63 - 1)
    temp65 <- (temp64 * 9)
    temp66 <- (temp65 + 2ee)
    temp67 <- (temp66 + 5)
    temp68 <- read-byte(temp67)
    if (temp68 = 72) is false then
        jump-to: LABEL 2d
LABEL 2c
    temp5a <- temp63
    temp63 <- 0
    jump-to: LABEL 2e
LABEL 2d
    temp63 <- temp68
LABEL 2e
    if (temp63 <> 0) is true then
        jump-to: LABEL 2b
LABEL 2f
    if (temp5a <> 0) is false then
        jump-to: LABEL 31
LABEL 30
    temp69 <- (temp5a - 1)
    temp6a <- (temp69 * 9)
    temp6b <- (temp6a + 2ee)
    temp6c <- (temp6b + 5)
    write-byte(temp6c) <- temp5b
LABEL 31
    if (temp5d = 72) is false then
        jump-to: LABEL 33
LABEL 32
    temp6d <- (temp5c - 1)
    temp6e <- (temp6d * 9)
    temp6f <- (temp6e + 2ee)
    temp70 <- (temp6f + 6)
    write-byte(temp70) <- temp5b
LABEL 33
    write-byte(6eb) <- 0
    write-byte(6ec) <- 0
    if (temp59 <> 0) is false then
        jump-to: LABEL 35
LABEL 34
    write-byte(6eb) <- temp59
    temp71 <- (temp59 - 1)
    temp72 <- (temp71 * 9)
    temp73 <- (temp72 + 2ee)
    temp74 <- (temp73 + 6)
    temp75 <- read-byte(temp74)
    write-byte(6ec) <- temp75
    temp76 <- (temp59 - 1)
    temp77 <- (temp76 * 9)
    temp78 <- (temp77 + 2ee)
    temp79 <- (temp78 + 6)
    write-byte(temp79) <- 72
LABEL 35
    temp7a <- read-byte(6e7)
    write-byte(6e7) <- byte(temp7a & not 0020)
    temp7b <- read-byte(6e7)
    write-byte(6e7) <- byte(temp7b | 0001)
    write-word(22af) <- 00
    jump-to: LABEL 01
LABEL 36
    temp7c <- L00
    temp7d <- (temp7c = be)
    if (temp7d) is true then
        jump-to: LABEL 38
LABEL 37
    temp7e <- L00
    push-SP: call 102c4 (temp7e)
    temp7f <- L04
    return: temp7f
LABEL 38
    temp80 <- L04
    return: temp80
]]>

        TestBinder(Zork1, &H101E0, expected)
    End Sub

#End Region

End Module
