﻿Public Module BinderTests_Advent

#Region "Advent_9524"

#Region "ZCode"
    '9525:  41 59 01 77             je              g49 #01 ~955e
    '9529:  0d 06 00                store           local5 #00
    '952c:  42 06 08 6c             jl              local5 #08 ~955a
    '9530:  42 06 00 c6             jl              local5 #00 9538
    '9534:  42 06 10 d2             jl              local5 #10 9548
    '9538:  fa 19 5f 5a 72 1d 06 0f 01 04 
    '                              call_vn2        169c8 #1d local5 #0f #01 #04
    '9542:  e8 7f 00                push            #00
    '9545:  8c 00 08                jump            954e
    '9548:  cf 2f 3e d7 06 00       loadw           #3ed7 local5 -> sp
    '954e:  f9 2a 5c d0 01 06 00    call_vn         17340 local0 local5 sp
    '9555:  95 06                   inc             local5
    '9557:  8c ff d4                jump            952c
    '955a:  0d 59 00                store           g49 #00
    '955d:  b0                      rtrue           
    '955e:  41 97 01 50             je              g87 #01 ~9570
    '9562:  0d 97 00                store           g87 #00
    '9565:  f9 03 24 92 41 b7 42 32 call_vn         9248 #41b7 #4232
    '956d:  8c 00 0a                jump            9578
    '9570:  f9 03 24 a6 41 b7 42 32 call_vn         9298 #41b7 #4232
    '9578:  0d 4e 01                store           g3e #01
    '957b:  02 01 00 c6             jl              #01 #00 9583
    '957f:  02 01 41 cf             jl              #01 #41 9590
    '9583:  fa 15 5f 5a 72 1c 01 40 04 0e 
    '                              call_vn2        169c8 #1c #01 #40 #04 #0e
    '958d:  8c 00 08                jump            9596
    '9590:  d0 1f 42 32 01 91       loadb           #4232 #01 -> g81
    '9596:  0d 90 01                store           g80 #01
    '9599:  8f 1a 9c                call_1n         6a70
    '959c:  f9 03 24 92 41 b7 42 32 call_vn         9248 #41b7 #4232
    '95a4:  8f 57 dc                call_1n         15f70
    '95a7:  02 01 00 c6             jl              #01 #00 95af
    '95ab:  02 01 41 cf             jl              #01 #41 95bc
    '95af:  fa 15 5f 5a 72 1c 01 40 04 0e 
    '                              call_vn2        169c8 #1c #01 #40 #04 #0e
    '95b9:  8c 00 08                jump            95c2
    '95bc:  d0 1f 42 32 01 91       loadb           #4232 #01 -> g81
    '95c2:  0d 08 00                store           local7 #00
    '95c5:  0d 93 01                store           g83 #01
    '95c8:  2d 4f 26                store           g3f g16
    '95cb:  d9 2f 28 86 26 50       call_2s         a218 g16 -> g40
    '95d1:  0d 94 00                store           g84 #00
    '95d4:  0d 85 00                store           g75 #00
    '95d7:  cd 4f 69 ff ff          store           g59 #ffff
    '95dc:  2d 90 93                store           g80 g83
    '95df:  88 33 a6 92             call_1s         ce98 -> g82
    '95e3:  c1 8f 92 ff ff 48       je              g82 #ffff ~95ef
    '95e9:  0d 5d 01                store           g4d #01
    '95ec:  8c 08 bd                jump            9eaa
    '95ef:  c1 83 92 58 30 4f 03 47 je              g82 "g" "again" ~95fc
    '95f7:  cd 4f 92 4f 03          store           g82 "again"
    '95fc:  c1 8f 92 4f 03 00 87    je              g82 "again" ~9688
    '9603:  61 4f 26 cc             je              g3f g16 9611
    '9607:  f9 07 4e a2 10 07 14    call_vn         13a88 #1007 #14
    '960e:  8c ff 61                jump            9570
    '9611:  02 01 00 c6             jl              #01 #00 9619
    '9615:  02 01 7b d2             jl              #01 #7b 9629
    '9619:  fa 15 5f 5a 72 1c 01 7a 00 11 
    '                              call_vn2        169c8 #1c #01 #7a #00 #11
    '9623:  e8 7f 00                push            #00
    '9626:  8c 00 08                jump            962f
    '9629:  d0 1f 43 2f 01 00       loadb           #432f #01 -> sp
    '962f:  a0 00 4c                jz              sp ~963c
    '9632:  f9 07 4e a2 10 07 15    call_vn         13a88 #1007 #15
    '9639:  8c ff 36                jump            9570
    '963c:  0d 06 00                store           local5 #00
    '963f:  42 06 78 00 43          jl              local5 #78 ~9685
    '9644:  42 06 00 c6             jl              local5 #00 964c
    '9648:  42 06 7b d2             jl              local5 #7b 965c
    '964c:  fa 19 5f 5a 72 1c 06 7a 00 11 
    '                              call_vn2        169c8 #1c local5 #7a #00 #11
    '9656:  e8 7f 00                push            #00
    '9659:  8c 00 08                jump            9662
    '965c:  d0 2f 43 2f 06 00       loadb           #432f local5 -> sp
    '9662:  42 06 00 c6             jl              local5 #00 966a
    '9666:  42 06 7b d2             jl              local5 #7b 967a
    '966a:  fa 19 5f 5a 72 1e 06 7a 00 0d 
    '                              call_vn2        169c8 #1e local5 #7a #00 #0d
    '9674:  a0 00 42                jz              sp ~9677
    '9677:  8c 00 08                jump            9680
    '967a:  e2 2b 41 b7 06 00       storeb          #41b7 local5 sp
    '9680:  95 06                   inc             local5
    '9682:  8c ff bc                jump            963f
    '9685:  8c fe f2                jump            9578
    '9688:  c1 8f 92 4f 03 80 4b    je              g82 "again" 96d8
    '968f:  0d 06 00                store           local5 #00
    '9692:  42 06 78 00 43          jl              local5 #78 ~96d8
    '9697:  42 06 00 c6             jl              local5 #00 969f
    '969b:  42 06 7b d2             jl              local5 #7b 96af
    '969f:  fa 19 5f 5a 72 1c 06 7a 00 0d 
    '                              call_vn2        169c8 #1c local5 #7a #00 #0d
    '96a9:  e8 7f 00                push            #00
    '96ac:  8c 00 08                jump            96b5
    '96af:  d0 2f 41 b7 06 00       loadb           #41b7 local5 -> sp
    '96b5:  42 06 00 c6             jl              local5 #00 96bd
    '96b9:  42 06 7b d2             jl              local5 #7b 96cd
    '96bd:  fa 19 5f 5a 72 1e 06 7a 00 11 
    '                              call_vn2        169c8 #1e local5 #7a #00 #11
    '96c7:  a0 00 42                jz              sp ~96ca
    '96ca:  8c 00 08                jump            96d3
    '96cd:  e2 2b 43 2f 06 00       storeb          #432f local5 sp
    '96d3:  95 06                   inc             local5
    '96d5:  8c ff bc                jump            9692
    '96d8:  a0 94 00 7b             jz              g84 ~9755
    '96dc:  2d 07 93                store           local6 g83
    '96df:  e0 27 38 11 4f 1c 06    call_vs         e044 g3f #1c -> local5
    '96e6:  c1 97 06 00 01 fa       je              local5 #00 #01 9724
    '96ec:  e0 2b 3c 1b 06 9a 00    call_vs         f06c local5 g8a -> sp
    '96f3:  42 00 00 e8             jl              sp #00 971d
    '96f7:  e0 2b 3c 1b 06 9c 00    call_vs         f06c local5 g8c -> sp
    '96fe:  42 00 00 5d             jl              sp #00 ~971d
    '9702:  75 06 9a 00             sub             local5 g8a -> sp
    '9706:  e9 7f ff                pull            gef
    '9709:  2d fe 9b                store           gee g8b
    '970c:  a0 fe 49                jz              gee ~9716
    '970f:  f9 1f 5a 72 14          call_vn         169c8 #14
    '9714:  95 fe                   inc             gee
    '9716:  78 ff fe 00             mod             gef gee -> sp
    '971a:  a0 00 c9                jz              sp 9724
    '971d:  2d 94 07                store           g84 local6
    '9720:  35 00 06 06             sub             #00 local5 -> local5
    '9724:  41 06 01 58             je              local5 #01 ~973e
    '9728:  f9 26 5c d0 01 00 42    call_vn         17340 local0 #00 g32
    '972f:  f9 26 5c d0 01 01 45    call_vn         17340 local0 #01 g35
    '9736:  f9 26 5c d0 01 02 46    call_vn         17340 local0 #02 g36
    '973d:  b0                      rtrue           
    '973e:  a0 06 cc                jz              local5 974b
    '9741:  2d 92 06                store           g82 local5
    '9744:  96 90                   dec             g80
    '9746:  96 93                   dec             g83
    '9748:  8c 00 09                jump            9752
    '974b:  2d 90 93                store           g80 g83
    '974e:  88 33 8d 92             call_1s         ce34 -> g82
    '9752:  8c 00 05                jump            9758
    '9755:  0d 94 00                store           g84 #00
    '9758:  a0 92 d1                jz              g82 976a
    '975b:  e0 27 5c a1 92 06 00    call_vs         17284 g82 #06 -> sp
    '9762:  49 00 01 00             and             sp #01 -> sp
    '9766:  a0 00 01 20             jz              sp ~9888
    '976a:  2d 90 93                store           g80 g83
    '976d:  0d 75 00                store           g65 #00
    '9770:  0d 6e 00                store           g5e #00
    '9773:  e0 15 2a e9 06 00 00 0a call_vs         aba4 #06 #00 #00 -> local9
    '977b:  c1 8f 0a 27 10 45       je              local9 #2710 ~9784
    '9781:  8c fd f6                jump            9578
    '9784:  a0 0a dd                jz              local9 97a2
    '9787:  f9 25 5c d0 01 00 1b    call_vn         17340 local0 #00 #1b
    '978e:  0d 69 1b                store           g59 #1b
    '9791:  f9 25 5c d0 01 01 01    call_vn         17340 local0 #01 #01
    '9798:  f9 26 5c d0 01 02 0a    call_vn         17340 local0 #02 local9
    '979f:  8c 09 ce                jump            a16e
    '97a2:  61 4f 26 67             je              g3f g16 ~97cb
    '97a6:  0d 07 02                store           local6 #02
    '97a9:  63 07 91 d4             jg              local6 g81 97bf
    '97ad:  88 33 8d 06             call_1s         ce34 -> local5
    '97b1:  c1 8f 06 53 32 45       je              local5 "comma," ~97ba
    '97b7:  8c 00 19                jump            97d1
    '97ba:  95 07                   inc             local6
    '97bc:  8c ff ec                jump            97a9
    '97bf:  d9 2f 57 0b 92 92       call_2s         15c2c g82 -> g82
    '97c5:  a0 92 c5                jz              g82 97cb
    '97c8:  8c 00 bf                jump            9888
    '97cb:  0d 5d 0c                store           g4d #0c
    '97ce:  8c 06 db                jump            9eaa
    '97d1:  55 90 01 07             sub             g80 #01 -> local6
    '97d5:  41 07 01 4c             je              local6 #01 ~97e3
    '97d9:  f9 07 4e a2 10 07 16    call_vn         13a88 #1007 #16
    '97e0:  8c fd 8f                jump            9570
    '97e3:  0d 90 01                store           g80 #01
    '97e6:  0d 70 01                store           g60 #01
    '97e9:  0d 84 01                store           g74 #01
    '97ec:  e0 29 2a e9 26 50 06 0a call_vs         aba4 g16 g40 #06 -> local9
    '97f4:  0d 84 00                store           g74 #00
    '97f7:  c1 8f 0a 27 10 45       je              local9 #2710 ~9800
    '97fd:  8c fd 7a                jump            9578
    '9800:  a0 0a 4c                jz              local9 ~980d
    '9803:  f9 07 4e a2 10 07 17    call_vn         13a88 #1007 #17
    '980a:  8c fd 65                jump            9570
    '980d:  23 01 0a c8             jg              #01 local9 9817
    '9811:  c3 8f 0a 01 14 4b       jg              local9 #0114 ~9820
    '9817:  f9 1b 5a 72 03 0a       call_vn         169c8 #03 local9
    '981d:  8c 00 06                jump            9824
    '9820:  4a 0a 00 e4             test_attr       local9 animate 9846
    '9824:  23 01 0a c8             jg              #01 local9 982e
    '9828:  c3 8f 0a 01 14 4b       jg              local9 #0114 ~9837
    '982e:  f9 1b 5a 72 03 0a       call_vn         169c8 #03 local9
    '9834:  8c 00 06                jump            983b
    '9837:  4a 0a 16 cd             test_attr       local9 talkable 9846
    '983b:  f9 06 4e a2 10 07 18 0a call_vn         13a88 #1007 #18 local9
    '9843:  8c fd 2c                jump            9570
    '9846:  61 90 07 cc             je              g80 local6 9854
    '984a:  f9 07 4e a2 10 07 19    call_vn         13a88 #1007 #19
    '9851:  8c fd 1e                jump            9570
    '9854:  da 2f 35 11 0a          call_2n         d444 local9
    '9859:  54 07 01 93             add             local6 #01 -> g83
    '985d:  61 0a 26 5d             je              local9 g16 ~987c
    '9861:  2d 90 93                store           g80 g83
    '9864:  88 33 a6 00             call_1s         ce98 -> sp
    '9868:  c1 80 00 4f 03 58 30 4f 03 4c 
    '                              je              sp "again" "g" "again" ~987c
    '9872:  f9 07 4e a2 10 07 14    call_vn         13a88 #1007 #14
    '9879:  8c fc f6                jump            9570
    '987c:  2d 4f 0a                store           g3f local9
    '987f:  d9 2f 28 86 0a 50       call_2s         a218 local9 -> g40
    '9885:  8c fd 56                jump            95dc
    '9888:  e0 27 5c a1 92 06 00    call_vs         17284 g82 #06 -> sp
    '988f:  49 00 02 00             and             sp #02 -> sp
    '9893:  57 00 02 51             div             sp #02 -> g41
    '9897:  41 51 01 4f             je              g41 #01 ~98a8
    '989b:  61 4f 26 cb             je              g3f g16 98a8
    '989f:  0d 5d 0c                store           g4d #0c
    '98a2:  0d 51 00                store           g41 #00
    '98a5:  8c 06 04                jump            9eaa
    '98a8:  e0 27 5c a1 92 07 00    call_vs         17284 g82 #07 -> sp
    '98af:  35 ff 00 06             sub             #ff sp -> local5
    '98b3:  e0 17 5c a9 0e 00 00    call_vs         172a4 #0e #00 -> sp
    '98ba:  e0 2b 5c a9 00 06 02    call_vs         172a4 sp local5 -> local1
    '98c1:  e0 27 5c a1 02 00 00    call_vs         17284 local1 #00 -> sp
    '98c8:  55 00 01 04             sub             sp #01 -> local3
    '98cc:  cd 4f 80 ff ff          store           g70 #ffff
    '98d1:  cd 4f 81 ff ff          store           g71 #ffff
    '98d6:  0d 5d 01                store           g4d #01
    '98d9:  0d 5e 01                store           g4e #01
    '98dc:  0d 52 00                store           g42 #00
    '98df:  54 02 01 05             add             local1 #01 -> local4
    '98e3:  0d 03 00                store           local2 #00
    '98e6:  63 03 04 85 c1          jg              local2 local3 9eaa
    '98eb:  0d 06 00                store           local5 #00
    '98ee:  42 06 20 00 58          jl              local5 #20 ~9949
    '98f3:  42 06 00 c6             jl              local5 #00 98fb
    '98f7:  42 06 20 cf             jl              local5 #20 9908
    '98fb:  fa 19 5f 5a 72 1f 06 1f 01 09 
    '                              call_vn2        169c8 #1f local5 #1f #01 #09
    '9905:  8c 00 08                jump            990e
    '9908:  e1 27 3f f7 06 0f       storew          #3ff7 local5 #0f
    '990e:  42 06 00 c6             jl              local5 #00 9916
    '9912:  42 06 20 cf             jl              local5 #20 9923
    '9916:  fa 19 5f 5a 72 1f 06 1f 01 07 
    '                              call_vn2        169c8 #1f local5 #1f #01 #07
    '9920:  8c 00 08                jump            9929
    '9923:  e1 27 3f 77 06 01       storew          #3f77 local5 #01
    '9929:  42 06 00 c6             jl              local5 #00 9931
    '992d:  42 06 20 cf             jl              local5 #20 993e
    '9931:  fa 19 5f 5a 72 1f 06 1f 01 08 
    '                              call_vn2        169c8 #1f local5 #1f #01 #08
    '993b:  8c 00 08                jump            9944
    '993e:  e1 27 3f b7 06 0f       storew          #3fb7 local5 #0f
    '9944:  95 06                   inc             local5
    '9946:  8c ff a7                jump            98ee
    '9949:  d9 2f 24 4d 05 05       call_2s         9134 local4 -> local4
    '994f:  0d 5b 00                store           g4b #00
    '9952:  0d 66 00                store           g56 #00
    '9955:  0d 61 00                store           g51 #00
    '9958:  0d 62 00                store           g52 #00
    '995b:  0d 54 00                store           g44 #00
    '995e:  0d 55 00                store           g45 #00
    '9961:  02 00 00 c6             jl              #00 #00 9969
    '9965:  02 00 40 cf             jl              #00 #40 9976
    '9969:  fa 15 5f 5a 72 1f 00 3f 01 03 
    '                              call_vn2        169c8 #1f #00 #3f #01 #03
    '9973:  8c 00 08                jump            997c
    '9976:  e1 17 3e 57 00 00       storew          #3e57 #00 #00
    '997c:  0d 74 00                store           g64 #00
    '997f:  0d 5c 01                store           g4c #01
    '9982:  54 93 01 90             add             g83 #01 -> g80
    '9986:  cd 4f 6b ff ff          store           g5b #ffff
    '998b:  0d 75 00                store           g65 #00
    '998e:  0d 06 00                store           local5 #00
    '9991:  0d 0b 00                store           local10 #00
    '9994:  0d 5f 00                store           g4f #00
    '9997:  42 5f 00 c6             jl              g4f #00 999f
    '999b:  42 5f 20 d2             jl              g4f #20 99af
    '999f:  fa 19 5f 5a 72 1d 5f 1f 01 09 
    '                              call_vn2        169c8 #1d g4f #1f #01 #09
    '99a9:  e8 7f 00                push            #00
    '99ac:  8c 00 08                jump            99b5
    '99af:  cf 2f 3f f7 5f 00       loadw           #3ff7 g4f -> sp
    '99b5:  41 00 0f 81 73          je              sp #0f 9b2b
    '99ba:  0d 85 00                store           g75 #00
    '99bd:  42 5f 00 c6             jl              g4f #00 99c5
    '99c1:  42 5f 20 d2             jl              g4f #20 99d5
    '99c5:  fa 19 5f 5a 72 1d 5f 1f 01 07 
    '                              call_vn2        169c8 #1d g4f #1f #01 #07
    '99cf:  e8 7f 00                push            #00
    '99d2:  8c 00 08                jump            99db
    '99d5:  cf 2f 3f 77 5f 00       loadw           #3f77 g4f -> sp
    '99db:  41 00 02 c4             je              sp #02 99e1
    '99df:  95 06                   inc             local5
    '99e1:  42 5f 00 c6             jl              g4f #00 99e9
    '99e5:  42 5f 20 d2             jl              g4f #20 99f9
    '99e9:  fa 19 5f 5a 72 1d 5f 1f 01 07 
    '                              call_vn2        169c8 #1d g4f #1f #01 #07
    '99f3:  e8 7f 00                push            #00
    '99f6:  8c 00 08                jump            99ff
    '99f9:  cf 2f 3f 77 5f 00       loadw           #3f77 g4f -> sp
    '99ff:  41 00 01 01 24          je              sp #01 ~9b26
    '9a04:  42 5f 00 c6             jl              g4f #00 9a0c
    '9a08:  42 5f 20 d2             jl              g4f #20 9a1c
    '9a0c:  fa 19 5f 5a 72 1d 5f 1f 01 08 
    '                              call_vn2        169c8 #1d g4f #1f #01 #08
    '9a16:  e8 7f 00                push            #00
    '9a19:  8c 00 08                jump            9a22
    '9a1c:  cf 2f 3f b7 5f 00       loadw           #3fb7 g4f -> sp
    '9a22:  41 00 02 45             je              sp #02 ~9a29
    '9a26:  0d 0b 01                store           local10 #01
    '9a29:  42 5f 00 c6             jl              g4f #00 9a31
    '9a2d:  42 5f 20 d2             jl              g4f #20 9a41
    '9a31:  fa 19 5f 5a 72 1d 5f 1f 01 08 
    '                              call_vn2        169c8 #1d g4f #1f #01 #08
    '9a3b:  e8 7f 00                push            #00
    '9a3e:  8c 00 08                jump            9a47
    '9a41:  cf 2f 3f b7 5f 00       loadw           #3fb7 g4f -> sp
    '9a47:  c1 97 00 04 05 00 da    je              sp #04 #05 ~9b26
    '9a4e:  41 06 01 00 d5          je              local5 #01 ~9b26
    '9a53:  95 5f                   inc             g4f
    '9a55:  42 5f 00 c6             jl              g4f #00 9a5d
    '9a59:  42 5f 20 d2             jl              g4f #20 9a6d
    '9a5d:  fa 19 5f 5a 72 1d 5f 1f 01 07 
    '                              call_vn2        169c8 #1d g4f #1f #01 #07
    '9a67:  e8 7f 00                push            #00
    '9a6a:  8c 00 08                jump            9a73
    '9a6d:  cf 2f 3f 77 5f 00       loadw           #3f77 g4f -> sp
    '9a73:  41 00 02 00 ad          je              sp #02 ~9b23
    '9a78:  42 5f 00 c6             jl              g4f #00 9a80
    '9a7c:  42 5f 20 d2             jl              g4f #20 9a90
    '9a80:  fa 19 5f 5a 72 1d 5f 1f 01 07 
    '                              call_vn2        169c8 #1d g4f #1f #01 #07
    '9a8a:  e8 7f 00                push            #00
    '9a8d:  8c 00 08                jump            9a96
    '9a90:  cf 2f 3f 77 5f 00       loadw           #3f77 g4f -> sp
    '9a96:  41 00 02 47             je              sp #02 ~9a9f
    '9a9a:  95 5f                   inc             g4f
    '9a9c:  8c ff db                jump            9a78
    '9a9f:  42 5f 00 c6             jl              g4f #00 9aa7
    '9aa3:  42 5f 20 d2             jl              g4f #20 9ab7
    '9aa7:  fa 19 5f 5a 72 1d 5f 1f 01 07 
    '                              call_vn2        169c8 #1d g4f #1f #01 #07
    '9ab1:  e8 7f 00                push            #00
    '9ab4:  8c 00 08                jump            9abd
    '9ab7:  cf 2f 3f 77 5f 00       loadw           #3f77 g4f -> sp
    '9abd:  41 00 01 00 63          je              sp #01 ~9b23
    '9ac2:  42 5f 00 c6             jl              g4f #00 9aca
    '9ac6:  42 5f 20 d2             jl              g4f #20 9ada
    '9aca:  fa 19 5f 5a 72 1d 5f 1f 01 08 
    '                              call_vn2        169c8 #1d g4f #1f #01 #08
    '9ad4:  e8 7f 00                push            #00
    '9ad7:  8c 00 08                jump            9ae0
    '9ada:  cf 2f 3f b7 5f 00       loadw           #3fb7 g4f -> sp
    '9ae0:  a0 00 00 41             jz              sp ~9b23
    '9ae4:  62 90 91 00 3c          jl              g80 g81 ~9b23
    '9ae9:  88 33 8d 0a             call_1s         ce34 -> local9
    '9aed:  a0 0a f2                jz              local9 9b20
    '9af0:  e0 27 5c a1 0a 06 00    call_vs         17284 local9 #06 -> sp
    '9af7:  49 00 08 00             and             sp #08 -> sp
    '9afb:  a0 00 e4                jz              sp 9b20
    '9afe:  88 28 c3 0a             call_1s         a30c -> local9
    '9b02:  a0 0a c5                jz              local9 9b08
    '9b05:  2d 5c 0a                store           g4c local9
    '9b08:  e0 29 2a e9 50 4f 00 0a call_vs         aba4 g40 g3f #00 -> local9
    '9b10:  c1 8f 0a 27 10 45       je              local9 #2710 ~9b19
    '9b16:  8c fa 61                jump            9578
    '9b19:  42 0a 02 c5             jl              local9 #02 9b20
    '9b1d:  2d 6b 0a                store           g5b local9
    '9b20:  8c ff c3                jump            9ae4
    '9b23:  8c 00 07                jump            9b2b
    '9b26:  95 5f                   inc             g4f
    '9b28:  8c fe 6e                jump            9997
    '9b2b:  0d 7e 00                store           g6e #00
    '9b2e:  a0 0b cd                jz              local10 9b3c
    '9b31:  41 65 01 49             je              g55 #01 ~9b3c
    '9b35:  41 69 4e 45             je              g59 #4e ~9b3c
    '9b39:  0d 7e 01                store           g6e #01
    '9b3c:  0d 5b 00                store           g4b #00
    '9b3f:  0d 66 00                store           g56 #00
    '9b42:  0d 61 00                store           g51 #00
    '9b45:  0d 62 00                store           g52 #00
    '9b48:  0d 54 00                store           g44 #00
    '9b4b:  0d 55 00                store           g45 #00
    '9b4e:  02 00 00 c6             jl              #00 #00 9b56
    '9b52:  02 00 40 cf             jl              #00 #40 9b63
    '9b56:  fa 15 5f 5a 72 1f 00 3f 01 03 
    '                              call_vn2        169c8 #1f #00 #3f #01 #03
    '9b60:  8c 00 08                jump            9b69
    '9b63:  e1 17 3e 57 00 00       storew          #3e57 #00 #00
    '9b69:  0d 5c 01                store           g4c #01
    '9b6c:  54 93 01 90             add             g83 #01 -> g80
    '9b70:  0d 5f 01                store           g4f #01
    '9b73:  42 5f 00 c6             jl              g4f #00 9b7b
    '9b77:  42 5f 20 cf             jl              g4f #20 9b88
    '9b7b:  fa 19 5f 5a 72 1f 5f 1f 01 05 
    '                              call_vn2        169c8 #1f g4f #1f #01 #05
    '9b85:  8c 00 09                jump            9b8f
    '9b88:  e1 23 3e f7 5f ff ff    storew          #3ef7 g4f #ffff
    '9b8f:  0d 85 00                store           g75 #00
    '9b92:  55 5f 01 00             sub             g4f #01 -> sp
    '9b96:  e9 7f fe                pull            gee
    '9b99:  e8 bf fe                push            gee
    '9b9c:  42 fe 00 c6             jl              gee #00 9ba4
    '9ba0:  42 fe 20 d2             jl              gee #20 9bb4
    '9ba4:  fa 19 5f 5a 72 1d fe 1f 01 09 
    '                              call_vn2        169c8 #1d gee #1f #01 #09
    '9bae:  a0 00 42                jz              sp ~9bb1
    '9bb1:  8c 00 08                jump            9bba
    '9bb4:  cf 2f 3f f7 00 09       loadw           #3ff7 sp -> local8
    '9bba:  42 5f 00 c6             jl              g4f #00 9bc2
    '9bbe:  42 5f 20 cf             jl              g4f #20 9bcf
    '9bc2:  fa 19 5f 5a 72 1d 5f 1f 01 09 
    '                              call_vn2        169c8 #1d g4f #1f #01 #09
    '9bcc:  8c 00 08                jump            9bd5
    '9bcf:  cf 2f 3f f7 5f 70       loadw           #3ff7 g4f -> g60
    '9bd5:  41 09 0f 80 e4          je              local8 #0f 9cbc
    '9bda:  0d 84 00                store           g74 #00
    '9bdd:  0d 4e 01                store           g3e #01
    '9be0:  da 2f 24 44 09          call_2n         9110 local8
    '9be5:  41 69 5d 6d             je              g59 #5d ~9c14
    '9be9:  41 6c 01 69             je              g5c #01 ~9c14
    '9bed:  41 6d 09 65             je              g5d #09 ~9c14
    '9bf1:  02 02 00 c6             jl              #02 #00 9bf9
    '9bf5:  02 02 10 cf             jl              #02 #10 9c06
    '9bf9:  fa 15 5f 5a 72 1d 02 0f 01 02 
    '                              call_vn2        169c8 #1d #02 #0f #01 #02
    '9c03:  8c 00 08                jump            9c0c
    '9c06:  cf 1f 3e 37 02 0a       loadw           #3e37 #02 -> local9
    '9c0c:  96 90                   dec             g80
    '9c0e:  2d 07 90                store           local6 g80
    '9c11:  8c fb fb                jump            980d
    '9c14:  55 5f 01 00             sub             g4f #01 -> sp
    '9c18:  ec 2a bf 29 80 6c 6d 00 09 0a 
    '                              call_vs2        a600 g5c g5d sp local8 -> local9
    '9c22:  c2 8f 0a ff 38 52       jl              local9 #ff38 ~9c38
    '9c28:  d4 8f 0a 01 00 00       add             local9 #0100 -> sp
    '9c2e:  e0 1b 29 80 01 00 0a    call_vs         a600 #01 sp -> local9
    '9c35:  8c ff ec                jump            9c22
    '9c38:  0d 84 00                store           g74 #00
    '9c3b:  a0 0a 56                jz              local9 ~9c52
    '9c3e:  41 6c 02 cc             je              g5c #02 9c4c
    '9c42:  41 6c 01 46             je              g5c #01 ~9c4a
    '9c46:  41 6d 09 c4             je              g5d #09 9c4c
    '9c4a:  96 65                   dec             g55
    '9c4c:  0d 0a 01                store           local9 #01
    '9c4f:  8c 00 5a                jump            9caa
    '9c52:  42 0a 00 48             jl              local9 #00 ~9c5c
    '9c56:  0d 0a 00                store           local9 #00
    '9c59:  8c 00 50                jump            9caa
    '9c5c:  c1 8f 0a 27 10 80 49    je              local9 #2710 9caa
    '9c63:  41 0a 01 53             je              local9 #01 ~9c78
    '9c67:  a0 62 48                jz              g52 ~9c70
    '9c6a:  2d 63 56                store           g53 g46
    '9c6d:  8c 00 05                jump            9c73
    '9c70:  2d 64 56                store           g54 g46
    '9c73:  95 62                   inc             g52
    '9c75:  0d 0a 01                store           local9 #01
    '9c78:  41 0a 02 45             je              local9 #02 ~9c7f
    '9c7c:  0d 0a 00                store           local9 #00
    '9c7f:  54 61 02 00             add             g51 #02 -> sp
    '9c83:  f9 2a 5c d0 01 00 0a    call_vn         17340 local0 sp local9
    '9c8a:  95 61                   inc             g51
    '9c8c:  42 5f 00 c6             jl              g4f #00 9c94
    '9c90:  42 5f 20 cf             jl              g4f #20 9ca1
    '9c94:  fa 19 5f 5a 72 1f 5f 1f 01 05 
    '                              call_vn2        169c8 #1f g4f #1f #01 #05
    '9c9e:  8c 00 08                jump            9ca7
    '9ca1:  e1 2b 3e f7 5f 0a       storew          #3ef7 g4f local9
    '9ca7:  0d 0a 01                store           local9 #01
    '9caa:  c1 8f 0a 27 10 45       je              local9 #2710 ~9cb3
    '9cb0:  8c f8 c7                jump            9578
    '9cb3:  a0 0a 45                jz              local9 ~9cb9
    '9cb6:  8c 01 d1                jump            9e88
    '9cb9:  8c 01 c9                jump            9e83
    '9cbc:  63 90 91 80 72          jg              g80 g81 9d31
    '9cc1:  88 33 8d 0a             call_1s         ce34 -> local9
    '9cc5:  c1 80 0a 66 64 66 64 66 64 c8 
    '                              je              local9 "then" "then" "then" 9cd5
    '9ccf:  c1 8f 0a 53 32 4c       je              local9 "comma," ~9cdf
    '9cd5:  0d 97 01                store           g87 #01
    '9cd8:  55 90 01 98             sub             g80 #01 -> g88
    '9cdc:  8c 00 54                jump            9d31
    '9cdf:  0d 0b 00                store           local10 #00
    '9ce2:  42 0b 20 00 43          jl              local10 #20 ~9d28
    '9ce7:  42 0b 00 c6             jl              local10 #00 9cef
    '9ceb:  42 0b 20 d2             jl              local10 #20 9cff
    '9cef:  fa 19 5f 5a 72 1d 0b 1f 01 05 
    '                              call_vn2        169c8 #1d local10 #1f #01 #05
    '9cf9:  e8 7f 00                push            #00
    '9cfc:  8c 00 08                jump            9d05
    '9cff:  cf 2f 3e f7 0b 00       loadw           #3ef7 local10 -> sp
    '9d05:  42 0b 00 c6             jl              local10 #00 9d0d
    '9d09:  42 0b 20 d2             jl              local10 #20 9d1d
    '9d0d:  fa 19 5f 5a 72 1f 0b 1f 01 06 
    '                              call_vn2        169c8 #1f local10 #1f #01 #06
    '9d17:  a0 00 42                jz              sp ~9d1a
    '9d1a:  8c 00 08                jump            9d23
    '9d1d:  e1 2b 3f 37 0b 00       storew          #3f37 local10 sp
    '9d23:  95 0b                   inc             local10
    '9d25:  8c ff bc                jump            9ce2
    '9d28:  2d 60 5f                store           g50 g4f
    '9d2b:  0d 5c 02                store           g4c #02
    '9d2e:  8c 01 59                jump            9e88
    '9d31:  42 61 01 e9             jl              g51 #01 9d5c
    '9d35:  e0 27 5c a9 01 02 00    call_vs         172a4 local0 #02 -> sp
    '9d3c:  a0 00 5f                jz              sp ~9d5c
    '9d3f:  e0 27 5c a9 01 03 00    call_vs         172a4 local0 #03 -> sp
    '9d46:  d9 2f 2e a9 00 0a       call_2s         baa4 sp -> local9
    '9d4c:  a0 0a cf                jz              local9 9d5c
    '9d4f:  2d 5c 0a                store           g4c local9
    '9d52:  f9 26 5c d0 01 00 69    call_vn         17340 local0 #00 g59
    '9d59:  8c 01 2e                jump            9e88
    '9d5c:  42 61 02 e2             jl              g51 #02 9d80
    '9d60:  e0 27 5c a9 01 03 00    call_vs         172a4 local0 #03 -> sp
    '9d67:  a0 00 58                jz              sp ~9d80
    '9d6a:  e0 27 5c a9 01 02 00    call_vs         172a4 local0 #02 -> sp
    '9d71:  d9 2f 2e a9 00 0a       call_2s         baa4 sp -> local9
    '9d77:  a0 0a c8                jz              local9 9d80
    '9d7a:  2d 5c 0a                store           g4c local9
    '9d7d:  8c 01 0a                jump            9e88
    '9d80:  41 7e 02 53             je              g6e #02 ~9d95
    '9d84:  e0 27 5c a9 01 02 00    call_vs         172a4 local0 #02 -> sp
    '9d8b:  61 00 4f 48             je              sp g3f ~9d95
    '9d8f:  0d 5d 11                store           g4d #11
    '9d92:  8c 01 17                jump            9eaa
    '9d95:  0d 95 00                store           g85 #00
    '9d98:  a0 66 cf                jz              g56 9da8
    '9d9b:  b2 ...                  print           "("
    '9d9e:  da 2f 30 9a 66          call_2n         c268 g56
    '9da3:  b2 ...                  print           ")^"
    '9da8:  f9 26 5c d0 01 00 69    call_vn         17340 local0 #00 g59
    '9daf:  f9 26 5c d0 01 01 61    call_vn         17340 local0 #01 g51
    '9db6:  a0 6a ef                jz              g5a 9de6
    '9db9:  41 61 02 6b             je              g51 #02 ~9de6
    '9dbd:  e0 27 5c a9 01 02 06    call_vs         172a4 local0 #02 -> local5
    '9dc4:  e0 27 5c a9 01 03 00    call_vs         172a4 local0 #03 -> sp
    '9dcb:  f9 26 5c d0 01 02 00    call_vn         17340 local0 #02 sp
    '9dd2:  f9 26 5c d0 01 03 06    call_vn         17340 local0 #03 local5
    '9dd9:  41 62 02 4b             je              g52 #02 ~9de6
    '9ddd:  2d 06 63                store           local5 g53
    '9de0:  2d 63 64                store           g53 g54
    '9de3:  2d 64 06                store           g54 local5
    '9de6:  43 61 00 59             jg              g51 #00 ~9e01
    '9dea:  e0 27 5c a9 01 02 00    call_vs         172a4 local0 #02 -> sp
    '9df1:  42 00 02 ce             jl              sp #02 9e01
    '9df5:  e0 27 5c a9 01 02 00    call_vs         172a4 local0 #02 -> sp
    '9dfc:  da 2f 35 11 00          call_2n         d444 sp
    '9e01:  a0 5b 80 75             jz              g4b 9e78
    '9e05:  61 4f 26 00 70          je              g3f g16 ~9e78
    '9e0a:  0d 42 4e                store           g32 #4e
    '9e0d:  e0 27 38 11 5b 49 06    call_vs         e044 g4b #49 -> local5
    '9e14:  43 06 02 48             jg              local5 #02 ~9e1e
    '9e18:  0d 5d 06                store           g4d #06
    '9e1b:  8c 00 8e                jump            9eaa
    '9e1e:  42 06 02 00 57          jl              local5 #02 ~9e78
    '9e23:  41 06 01 ca             je              local5 #01 9e2f
    '9e27:  f9 06 4e a2 10 07 1a 5b call_vn         13a88 #1007 #1a g4b
    '9e2f:  0d 59 01                store           g49 #01
    '9e32:  0d 06 00                store           local5 #00
    '9e35:  42 06 08 6c             jl              local5 #08 ~9e63
    '9e39:  e0 2b 5c a9 01 06 00    call_vs         172a4 local0 local5 -> sp
    '9e40:  42 06 00 c6             jl              local5 #00 9e48
    '9e44:  42 06 10 d2             jl              local5 #10 9e58
    '9e48:  fa 19 5f 5a 72 1f 06 0f 01 04 
    '                              call_vn2        169c8 #1f local5 #0f #01 #04
    '9e52:  a0 00 42                jz              sp ~9e55
    '9e55:  8c 00 08                jump            9e5e
    '9e58:  e1 2b 3e d7 06 00       storew          #3ed7 local5 sp
    '9e5e:  95 06                   inc             local5
    '9e60:  8c ff d4                jump            9e35
    '9e63:  f9 25 5c d0 01 00 4e    call_vn         17340 local0 #00 #4e
    '9e6a:  f9 25 5c d0 01 01 01    call_vn         17340 local0 #01 #01
    '9e71:  f9 26 5c d0 01 02 5b    call_vn         17340 local0 #02 g4b
    '9e78:  41 97 01 48             je              g87 #01 ~9e82
    '9e7c:  2d 90 98                store           g80 g88
    '9e7f:  8c 02 ee                jump            a16e
    '9e82:  b0                      rtrue           
    '9e83:  95 5f                   inc             g4f
    '9e85:  8c fc ed                jump            9b73
    '9e88:  63 5c 5d 45             jg              g4c g4d ~9e8f
    '9e8c:  2d 5d 5c                store           g4d g4c
    '9e8f:  41 5c 12 c9             je              g4c #12 9e9a
    '9e93:  63 5c 5e 45             jg              g4c g4e ~9e9a
    '9e97:  2d 5e 5c                store           g4e g4c
    '9e9a:  41 7e 02 49             je              g6e #02 ~9ea5
    '9e9e:  41 5c 11 45             je              g4c #11 ~9ea5
    '9ea2:  8c 00 07                jump            9eaa
    '9ea5:  95 03                   inc             local2
    '9ea7:  8c fa 3e                jump            98e6
    '9eaa:  2d 5c 5d                store           g4c g4d
    '9ead:  61 4f 26 80 50          je              g3f g16 9f00
    '9eb2:  a0 94 c8                jz              g84 9ebb
    '9eb5:  2d 93 94                store           g83 g84
    '9eb8:  8c f7 1b                jump            95d4
    '9ebb:  2d 90 93                store           g80 g83
    '9ebe:  88 33 8d 54             call_1s         ce34 -> g44
    '9ec2:  c1 8f 54 53 32 48       je              g44 "comma," ~9ece
    '9ec8:  88 33 8d 54             call_1s         ce34 -> g44
    '9ecc:  95 93                   inc             g83
    '9ece:  d9 2f 33 cc 93 55       call_2s         cf30 g83 -> g45
    '9ed4:  f9 24 5c d0 01 00 10 09 call_vn         17340 local0 #00 #1009
    '9edc:  f9 25 5c d0 01 01 02    call_vn         17340 local0 #01 #02
    '9ee3:  f9 25 5c d0 01 02 01    call_vn         17340 local0 #02 #01
    '9eea:  2d 63 54                store           g53 g44
    '9eed:  f9 26 5c d0 01 03 4f    call_vn         17340 local0 #03 g3f
    '9ef4:  2d 57 93                store           g47 g83
    '9ef7:  75 91 57 00             sub             g81 g47 -> sp
    '9efb:  54 00 01 58             add             sp #01 -> g48
    '9eff:  b0                      rtrue           
    '9f00:  d9 2f 57 e5 5c 00       call_2s         15f94 g4c -> sp
    '9f06:  a0 00 c5                jz              sp 9f0c
    '9f09:  8c f6 66                jump            9570
    '9f0c:  2d 80 82                store           g70 g72
    '9f0f:  2d 81 83                store           g71 g73
    '9f12:  41 5c 01 4c             je              g4c #01 ~9f20
    '9f16:  f9 07 4e a2 10 07 1b    call_vn         13a88 #1007 #1b
    '9f1d:  0d 95 01                store           g85 #01
    '9f20:  41 5c 02 00 61          je              g4c #02 ~9f84
    '9f25:  f9 07 4e a2 10 07 1c    call_vn         13a88 #1007 #1c
    '9f2c:  0d 0b 00                store           local10 #00
    '9f2f:  42 0b 20 00 43          jl              local10 #20 ~9f75
    '9f34:  42 0b 00 c6             jl              local10 #00 9f3c
    '9f38:  42 0b 20 d2             jl              local10 #20 9f4c
    '9f3c:  fa 19 5f 5a 72 1d 0b 1f 01 06 
    '                              call_vn2        169c8 #1d local10 #1f #01 #06
    '9f46:  e8 7f 00                push            #00
    '9f49:  8c 00 08                jump            9f52
    '9f4c:  cf 2f 3f 37 0b 00       loadw           #3f37 local10 -> sp
    '9f52:  42 0b 00 c6             jl              local10 #00 9f5a
    '9f56:  42 0b 20 d2             jl              local10 #20 9f6a
    '9f5a:  fa 19 5f 5a 72 1f 0b 1f 01 05 
    '                              call_vn2        169c8 #1f local10 #1f #01 #05
    '9f64:  a0 00 42                jz              sp ~9f67
    '9f67:  8c 00 08                jump            9f70
    '9f6a:  e1 2b 3e f7 0b 00       storew          #3ef7 local10 sp
    '9f70:  95 0b                   inc             local10
    '9f72:  8c ff bc                jump            9f2f
    '9f75:  2d 5f 60                store           g4f g50
    '9f78:  da 1f 30 9a 00          call_2n         c268 #00
    '9f7d:  f9 07 4e a2 10 07 38    call_vn         13a88 #1007 #38
    '9f84:  41 5c 03 49             je              g4c #03 ~9f8f
    '9f88:  f9 07 4e a2 10 07 1d    call_vn         13a88 #1007 #1d
    '9f8f:  41 5c 04 4c             je              g4c #04 ~9f9d
    '9f93:  f9 07 4e a2 10 07 1e    call_vn         13a88 #1007 #1e
    '9f9a:  2d 95 96                store           g85 g86
    '9f9d:  41 5c 05 49             je              g4c #05 ~9fa8
    '9fa1:  f9 07 4e a2 10 07 1f    call_vn         13a88 #1007 #1f
    '9fa8:  41 5c 06 4c             je              g4c #06 ~9fb6
    '9fac:  f9 07 4e a2 10 07 20    call_vn         13a88 #1007 #20
    '9fb3:  2d 95 96                store           g85 g86
    '9fb6:  41 5c 07 49             je              g4c #07 ~9fc1
    '9fba:  f9 07 4e a2 10 07 21    call_vn         13a88 #1007 #21
    '9fc1:  41 5c 08 49             je              g4c #08 ~9fcc
    '9fc5:  f9 07 4e a2 10 07 22    call_vn         13a88 #1007 #22
    '9fcc:  41 5c 09 49             je              g4c #09 ~9fd7
    '9fd0:  f9 07 4e a2 10 07 23    call_vn         13a88 #1007 #23
    '9fd7:  41 5c 0a 49             je              g4c #0a ~9fe2
    '9fdb:  f9 07 4e a2 10 07 24    call_vn         13a88 #1007 #24
    '9fe2:  41 5c 0b 49             je              g4c #0b ~9fed
    '9fe6:  f9 07 4e a2 10 07 25    call_vn         13a88 #1007 #25
    '9fed:  41 5c 0c 49             je              g4c #0c ~9ff8
    '9ff1:  f9 07 4e a2 10 07 26    call_vn         13a88 #1007 #26
    '9ff8:  41 5c 0d 49             je              g4c #0d ~a003
    '9ffc:  f9 07 4e a2 10 07 27    call_vn         13a88 #1007 #27
    'a003:  41 5c 0e 59             je              g4c #0e ~a01e
    'a007:  c1 8f 81 ff ff 4c       je              g71 #ffff ~a017
    'a00d:  f9 07 4e a2 10 07 23    call_vn         13a88 #1007 #23
    'a014:  8c 00 09                jump            a01e
    'a017:  f9 07 4e a2 10 07 28    call_vn         13a88 #1007 #28
    'a01e:  41 5c 0f 49             je              g4c #0f ~a029
    'a022:  f9 07 4e a2 10 07 29    call_vn         13a88 #1007 #29
    'a029:  41 5c 10 4a             je              g4c #10 ~a035
    'a02d:  f9 06 4e a2 10 07 2a 73 call_vn         13a88 #1007 #2a g63
    'a035:  41 5c 11 01 1d          je              g4c #11 ~a155
    'a03a:  e0 27 5c a9 01 00 00    call_vs         172a4 local0 #00 -> sp
    'a041:  41 00 38 00 f1          je              sp #38 ~a135
    'a046:  e0 27 5c a9 01 03 00    call_vs         172a4 local0 #03 -> sp
    'a04d:  e0 27 5a 0b 00 02 00    call_vs         1682c sp #02 -> sp
    'a054:  a0 00 80 df             jz              sp a135
    'a058:  e0 27 5c a9 01 03 45    call_vs         172a4 local0 #03 -> g35
    'a05f:  23 01 45 c8             jg              #01 g35 a069
    'a063:  c3 8f 45 01 14 4b       jg              g35 #0114 ~a072
    'a069:  f9 1b 5a 72 03 45       call_vn         169c8 #03 g35
    'a06f:  8c 00 10                jump            a080
    'a072:  4a 45 00 4c             test_attr       g35 animate ~a080
    'a076:  f9 16 4e a2 4e 06 45    call_vn         13a88 #4e #06 g35
    'a07d:  8c 00 b7                jump            a135
    'a080:  23 01 45 c8             jg              #01 g35 a08a
    'a084:  c3 8f 45 01 14 4b       jg              g35 #0114 ~a093
    'a08a:  f9 1b 5a 72 03 45       call_vn         169c8 #03 g35
    'a090:  8c 00 06                jump            a097
    'a093:  4a 45 04 e3             test_attr       g35 container a0b8
    'a097:  23 01 45 c8             jg              #01 g35 a0a1
    'a09b:  c3 8f 45 01 14 4b       jg              g35 #0114 ~a0aa
    'a0a1:  f9 1b 5a 72 03 45       call_vn         169c8 #03 g35
    'a0a7:  8c 00 06                jump            a0ae
    'a0aa:  4a 45 14 cc             test_attr       g35 supporter a0b8
    'a0ae:  f9 16 4e a2 1c 02 45    call_vn         13a88 #1c #02 g35
    'a0b5:  8c 00 7f                jump            a135
    'a0b8:  23 01 45 c8             jg              #01 g35 a0c2
    'a0bc:  c3 8f 45 01 14 4b       jg              g35 #0114 ~a0cb
    'a0c2:  f9 1b 5a 72 03 45       call_vn         169c8 #03 g35
    'a0c8:  8c 00 27                jump            a0f0
    'a0cb:  4a 45 04 63             test_attr       g35 container ~a0f0
    'a0cf:  23 01 45 c8             jg              #01 g35 a0d9
    'a0d3:  c3 8f 45 01 14 4b       jg              g35 #0114 ~a0e2
    'a0d9:  f9 1b 5a 72 03 45       call_vn         169c8 #03 g35
    'a0df:  8c 00 06                jump            a0e6
    'a0e2:  4a 45 0e cc             test_attr       g35 open a0f0
    'a0e6:  f9 16 4e a2 4e 09 45    call_vn         13a88 #4e #09 g35
    'a0ed:  8c 00 47                jump            a135
    'a0f0:  23 05 45 cc             jg              #05 g35 a0fe
    'a0f4:  c3 8f 45 01 14 c6       jg              g35 #0114 a0fe
    'a0fa:  46 45 01 4e             jin             g35 "Class" ~a10a
    'a0fe:  f9 1b 5a 72 09 45       call_vn         169c8 #09 g35
    'a104:  0d fe 02                store           gee #02
    'a107:  8c 00 05                jump            a10d
    'a10a:  2d fe 45                store           gee g35
    'a10d:  0d ff 00                store           gef #00
    'a110:  a2 fe 00 49             get_child       gee -> sp ~a11b
    'a114:  95 ff                   inc             gef
    'a116:  a1 00 00 bf fb          get_sibling     sp -> sp a114
    'a11b:  e9 7f fe                pull            gee
    'a11e:  e8 bf ff                push            gef
    'a121:  a0 00 4c                jz              sp ~a12e
    'a124:  f9 16 4e a2 40 06 45    call_vn         13a88 #40 #06 g35
    'a12b:  8c 00 09                jump            a135
    'a12e:  f9 25 5c d0 01 00 00    call_vn         17340 local0 #00 #00
    'a135:  e0 27 5c a9 01 00 00    call_vs         172a4 local0 #00 -> sp
    'a13c:  41 00 38 d7             je              sp #38 a155
    'a140:  41 72 64 4c             je              g62 #64 ~a14e
    'a144:  f9 07 4e a2 10 07 2b    call_vn         13a88 #1007 #2b
    'a14b:  8c 00 09                jump            a155
    'a14e:  f9 07 4e a2 10 07 2c    call_vn         13a88 #1007 #2c
    'a155:  41 5c 12 54             je              g4c #12 ~a16b
    'a159:  0d 87 03                store           g77 #03
    'a15c:  a8 86 00                call_1s         g76 -> sp
    'a15f:  c1 8f 00 ff ff 48       je              sp #ffff ~a16b
    'a165:  2d 5d 5e                store           g4d g4e
    'a168:  8c fd 41                jump            9eaa
    'a16b:  8c f4 04                jump            9570
    'a16e:  63 90 91 c1             jg              g80 g81 rtrue
    'a172:  88 33 8d 06             call_1s         ce34 -> local5
    'a176:  c1 80 06 66 64 66 64 66 64 c9 
    '                              je              local5 "then" "then" "then" a187
    'a180:  c1 8f 06 53 32 00 8b    je              local5 "comma," ~a210
    'a187:  63 90 91 46             jg              g80 g81 ~a18f
    'a18b:  0d 97 00                store           g87 #00
    'a18e:  b0                      rtrue           
    'a18f:  d9 2f 33 b2 93 06       call_2s         cec8 g83 -> local5
    'a195:  d9 2f 33 b2 90 07       call_2s         cec8 g80 -> local6
    'a19b:  62 06 07 4e             jl              local5 local6 ~a1ab
    'a19f:  f9 25 5c b2 06 00 20    call_vn         172c8 local5 #00 #20
    'a1a6:  95 06                   inc             local5
    'a1a8:  8c ff f2                jump            a19b
    'a1ab:  88 33 8d 06             call_1s         ce34 -> local5
    'a1af:  c1 80 06 4f 03 58 30 4f 03 00 4c 
    '                              je              local5 "again" "g" "again" ~a204
    'a1ba:  55 90 02 00             sub             g80 #02 -> sp
    'a1be:  d9 2f 33 b2 00 00       call_2s         cec8 sp -> sp
    'a1c4:  d5 8f 00 41 b7 06       sub             sp #41b7 -> local5
    'a1ca:  63 90 91 48             jg              g80 g81 ~a1d4
    'a1ce:  0d 07 77                store           local6 #77
    'a1d1:  8c 00 0e                jump            a1e0
    'a1d4:  d9 2f 33 b2 90 00       call_2s         cec8 g80 -> sp
    'a1da:  d5 8f 00 41 b7 07       sub             sp #41b7 -> local6
    'a1e0:  62 06 07 62             jl              local5 local6 ~a204
    'a1e4:  42 06 00 c6             jl              local5 #00 a1ec
    'a1e8:  42 06 7b cf             jl              local5 #7b a1f9
    'a1ec:  fa 19 5f 5a 72 1e 06 7a 00 11 
    '                              call_vn2        169c8 #1e local5 #7a #00 #11
    'a1f6:  8c 00 08                jump            a1ff
    'a1f9:  e2 27 43 2f 06 20       storeb          #432f local5 #20
    'a1ff:  95 06                   inc             local5
    'a201:  8c ff de                jump            a1e0
    'a204:  f9 03 24 92 41 b7 42 32 call_vn         9248 #41b7 #4232
    'a20c:  0d 97 01                store           g87 #01
    'a20f:  b0                      rtrue           
    'a210:  0d 5d 02                store           g4d #02
    'a213:  8c fc 96                jump            9eaa
#End Region

    <Fact>
    Sub Advent_9524()
        Dim expected =
<![CDATA[
# temps: 326

LABEL 00
    temp00 <- L00
    temp01 <- L08
LABEL 01
    temp02 <- read-word(3c7b)
    if (temp02 = 01) is false then
        jump-to: LABEL 0a
LABEL 02
    temp03 <- 00
LABEL 03
    if (int16(temp03) < int16(08)) is false then
        jump-to: LABEL 09
LABEL 04
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 06
LABEL 05
    if (int16(temp03) < int16(10)) is true then
        jump-to: LABEL 07
LABEL 06
    discard: call 169c8 (1d, temp03, 0f, 01, 04)
    push-SP: 00
    jump-to: LABEL 08
LABEL 07
    push-SP: read-word(3ed7 + (temp03 * 2))
LABEL 08
    temp04 <- pop-SP
    discard: call 17340 (temp00, temp03, temp04)
    temp03 <- (int16(temp03) + int16(1))
    jump-to: LABEL 03
LABEL 09
    write-word(3c7b) <- 00
    return: 1
LABEL 0a
    temp05 <- read-word(3cf7)
    if (temp05 = 01) is false then
        jump-to: LABEL 0c
LABEL 0b
    write-word(3cf7) <- 00
    discard: call 9248 (41b7, 4232)
    jump-to: LABEL 0d
LABEL 0c
    discard: call 9298 (41b7, 4232)
LABEL 0d
    write-word(3c65) <- 01
    write-word(3ceb) <- read-byte(4233)
    write-word(3ce9) <- 01
    discard: call 6a70 ()
    discard: call 9248 (41b7, 4232)
    discard: call 15f70 ()
    write-word(3ceb) <- read-byte(4233)
    write-word(3cef) <- 01
    temp06 <- read-word(3c15)
    write-word(3c67) <- temp06
    temp07 <- read-word(3c15)
    write-word(3c69) <- call a218 (temp07)
    write-word(3cf1) <- 00
LABEL 0e
    write-word(3cd3) <- 00
    write-word(3c9b) <- ffff
LABEL 0f
    temp08 <- read-word(3cef)
    write-word(3ce9) <- temp08
    write-word(3ced) <- call ce98 ()
    temp09 <- read-word(3ced)
    if (temp09 = ffff) is false then
        jump-to: LABEL 11
LABEL 10
    write-word(3c83) <- 01
    jump-to: LABEL 12d
LABEL 11
    temp0a <- read-word(3ced)
    if ((temp0a = 5830) | (temp0a = 4f03)) is false then
        jump-to: LABEL 13
LABEL 12
    write-word(3ced) <- 4f03
LABEL 13
    temp0b <- read-word(3ced)
    if (temp0b = 4f03) is false then
        jump-to: LABEL 25
LABEL 14
    temp0c <- read-word(3c67)
    temp0d <- read-word(3c15)
    if (temp0c = temp0d) is true then
        jump-to: LABEL 16
LABEL 15
    discard: call 13a88 (1007, 14)
    jump-to: LABEL 0c
LABEL 16
    temp0e <- read-byte(4330)
    if (temp0e = 0) is false then
        jump-to: LABEL 18
LABEL 17
    discard: call 13a88 (1007, 15)
    jump-to: LABEL 0c
LABEL 18
    temp03 <- 00
LABEL 19
    if (int16(temp03) < int16(78)) is false then
        jump-to: LABEL 24
LABEL 1a
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 1c
LABEL 1b
    if (int16(temp03) < int16(7b)) is true then
        jump-to: LABEL 1d
LABEL 1c
    discard: call 169c8 (1c, temp03, 7a, 00, 11)
    push-SP: 00
    jump-to: LABEL 1e
LABEL 1d
    push-SP: read-byte(432f + temp03)
LABEL 1e
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 20
LABEL 1f
    if (int16(temp03) < int16(7b)) is true then
        jump-to: LABEL 22
LABEL 20
    discard: call 169c8 (1e, temp03, 7a, 00, 0d)
    temp0f <- pop-SP
    if (temp0f = 0) is false then
        jump-to: LABEL 21
LABEL 21
    jump-to: LABEL 23
LABEL 22
    temp10 <- pop-SP
    write-byte(41b7 + temp03) <- temp10
LABEL 23
    temp03 <- (int16(temp03) + int16(1))
    jump-to: LABEL 19
LABEL 24
    jump-to: LABEL 0d
LABEL 25
    temp11 <- read-word(3ced)
    if (temp11 = 4f03) is true then
        jump-to: LABEL 32
LABEL 26
    temp03 <- 00
LABEL 27
    if (int16(temp03) < int16(78)) is false then
        jump-to: LABEL 32
LABEL 28
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 2a
LABEL 29
    if (int16(temp03) < int16(7b)) is true then
        jump-to: LABEL 2b
LABEL 2a
    discard: call 169c8 (1c, temp03, 7a, 00, 0d)
    push-SP: 00
    jump-to: LABEL 2c
LABEL 2b
    push-SP: read-byte(41b7 + temp03)
LABEL 2c
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 2e
LABEL 2d
    if (int16(temp03) < int16(7b)) is true then
        jump-to: LABEL 30
LABEL 2e
    discard: call 169c8 (1e, temp03, 7a, 00, 11)
    temp12 <- pop-SP
    if (temp12 = 0) is false then
        jump-to: LABEL 2f
LABEL 2f
    jump-to: LABEL 31
LABEL 30
    temp13 <- pop-SP
    write-byte(432f + temp03) <- temp13
LABEL 31
    temp03 <- (int16(temp03) + int16(1))
    jump-to: LABEL 27
LABEL 32
    temp14 <- read-word(3cf1)
    if (temp14 = 0) is false then
        jump-to: LABEL 40
LABEL 33
    temp15 <- read-word(3cef)
    temp16 <- read-word(3c67)
    temp03 <- call e044 (temp16, 1c)
    temp17 <- temp03
    if ((temp17 = 00) | (temp17 = 01)) is true then
        jump-to: LABEL 3a
LABEL 34
    temp18 <- read-word(3cfd)
    temp19 <- call f06c (temp03, temp18)
    if (int16(temp19) < int16(00)) is true then
        jump-to: LABEL 39
LABEL 35
    temp1a <- read-word(3d01)
    temp1b <- call f06c (temp03, temp1a)
    if (int16(temp1b) < int16(00)) is false then
        jump-to: LABEL 39
LABEL 36
    temp1c <- read-word(3cfd)
    temp1d <- (int16(temp03) - int16(temp1c))
    write-word(3dc7) <- temp1d
    temp1e <- read-word(3cff)
    write-word(3dc5) <- temp1e
    temp1f <- read-word(3dc5)
    if (temp1f = 0) is false then
        jump-to: LABEL 38
LABEL 37
    discard: call 169c8 (14)
    temp20 <- read-word(3dc5)
    write-word(3dc5) <- (int16(temp20) + int16(1))
LABEL 38
    temp21 <- read-word(3dc7)
    temp22 <- read-word(3dc5)
    temp23 <- (int16(temp21) % int16(temp22))
    if (temp23 = 0) is true then
        jump-to: LABEL 3a
LABEL 39
    write-word(3cf1) <- temp15
    temp03 <- (int16(00) - int16(temp03))
LABEL 3a
    if (temp03 = 01) is false then
        jump-to: LABEL 3c
LABEL 3b
    temp24 <- read-word(3c4d)
    discard: call 17340 (temp00, 00, temp24)
    temp25 <- read-word(3c53)
    discard: call 17340 (temp00, 01, temp25)
    temp26 <- read-word(3c55)
    discard: call 17340 (temp00, 02, temp26)
    return: 1
LABEL 3c
    if (temp03 = 0) is true then
        jump-to: LABEL 3e
LABEL 3d
    write-word(3ced) <- temp03
    temp27 <- read-word(3ce9)
    write-word(3ce9) <- (int16(temp27) - int16(1))
    temp28 <- read-word(3cef)
    write-word(3cef) <- (int16(temp28) - int16(1))
    jump-to: LABEL 3f
LABEL 3e
    temp29 <- read-word(3cef)
    write-word(3ce9) <- temp29
    write-word(3ced) <- call ce34 ()
LABEL 3f
    jump-to: LABEL 41
LABEL 40
    write-word(3cf1) <- 00
LABEL 41
    temp2a <- read-word(3ced)
    if (temp2a = 0) is true then
        jump-to: LABEL 43
LABEL 42
    temp2b <- read-word(3ced)
    temp2c <- call 17284 (temp2b, 06)
    temp2d <- (temp2c & 01)
    if (temp2d = 0) is false then
        jump-to: LABEL 65
LABEL 43
    temp2e <- read-word(3cef)
    write-word(3ce9) <- temp2e
    write-word(3cb3) <- 00
    write-word(3ca5) <- 00
    temp2f <- call aba4 (06, 00, 00)
    if (temp2f = 2710) is false then
        jump-to: LABEL 45
LABEL 44
    jump-to: LABEL 0d
LABEL 45
    if (temp2f = 0) is true then
        jump-to: LABEL 47
LABEL 46
    discard: call 17340 (temp00, 00, 1b)
    write-word(3c9b) <- 1b
    discard: call 17340 (temp00, 01, 01)
    discard: call 17340 (temp00, 02, temp2f)
    jump-to: LABEL 192
LABEL 47
    temp30 <- read-word(3c67)
    temp31 <- read-word(3c15)
    if (temp30 = temp31) is false then
        jump-to: LABEL 4f
LABEL 48
    temp32 <- 02
LABEL 49
    temp33 <- read-word(3ceb)
    if (int16(temp32) > int16(temp33)) is true then
        jump-to: LABEL 4d
LABEL 4a
    temp03 <- call ce34 ()
    if (temp03 = 5332) is false then
        jump-to: LABEL 4c
LABEL 4b
    jump-to: LABEL 50
LABEL 4c
    temp32 <- (int16(temp32) + int16(1))
    jump-to: LABEL 49
LABEL 4d
    temp34 <- read-word(3ced)
    write-word(3ced) <- call 15c2c (temp34)
    temp35 <- read-word(3ced)
    if (temp35 = 0) is true then
        jump-to: LABEL 4f
LABEL 4e
    jump-to: LABEL 65
LABEL 4f
    write-word(3c83) <- 0c
    jump-to: LABEL 12d
LABEL 50
    temp36 <- read-word(3ce9)
    temp32 <- (int16(temp36) - int16(01))
    if (temp32 = 01) is false then
        jump-to: LABEL 52
LABEL 51
    discard: call 13a88 (1007, 16)
    jump-to: LABEL 0c
LABEL 52
    write-word(3ce9) <- 01
    write-word(3ca9) <- 01
    write-word(3cd1) <- 01
    temp37 <- read-word(3c15)
    temp38 <- read-word(3c69)
    temp2f <- call aba4 (temp37, temp38, 06)
    write-word(3cd1) <- 00
    if (temp2f = 2710) is false then
        jump-to: LABEL 54
LABEL 53
    jump-to: LABEL 0d
LABEL 54
    if (temp2f = 0) is false then
        jump-to: LABEL 56
LABEL 55
    discard: call 13a88 (1007, 17)
    jump-to: LABEL 0c
LABEL 56
    if (int16(01) > int16(temp2f)) is true then
        jump-to: LABEL 58
LABEL 57
    if (int16(temp2f) > int16(0114)) is false then
        jump-to: LABEL 59
LABEL 58
    discard: call 169c8 (03, temp2f)
    jump-to: LABEL 5a
LABEL 59
    if (((read-byte(((temp2f - 1) * e) + 188) & 0080) <> 0) = 1) is true then
        jump-to: LABEL 5f
LABEL 5a
    if (int16(01) > int16(temp2f)) is true then
        jump-to: LABEL 5c
LABEL 5b
    if (int16(temp2f) > int16(0114)) is false then
        jump-to: LABEL 5d
LABEL 5c
    discard: call 169c8 (03, temp2f)
    jump-to: LABEL 5e
LABEL 5d
    if (((read-byte((((temp2f - 1) * e) + 188) + 2) & 0002) <> 0) = 1) is true then
        jump-to: LABEL 5f
LABEL 5e
    discard: call 13a88 (1007, 18, temp2f)
    jump-to: LABEL 0c
LABEL 5f
    temp39 <- read-word(3ce9)
    if (temp39 = temp32) is true then
        jump-to: LABEL 61
LABEL 60
    discard: call 13a88 (1007, 19)
    jump-to: LABEL 0c
LABEL 61
    discard: call d444 (temp2f)
    write-word(3cef) <- (int16(temp32) + int16(01))
    temp3a <- read-word(3c15)
    if (temp2f = temp3a) is false then
        jump-to: LABEL 64
LABEL 62
    temp3b <- read-word(3cef)
    write-word(3ce9) <- temp3b
    temp3c <- call ce98 ()
    if (((temp3c = 4f03) | (temp3c = 5830)) | (temp3c = 4f03)) is false then
        jump-to: LABEL 64
LABEL 63
    discard: call 13a88 (1007, 14)
    jump-to: LABEL 0c
LABEL 64
    write-word(3c67) <- temp2f
    write-word(3c69) <- call a218 (temp2f)
    jump-to: LABEL 0f
LABEL 65
    temp3d <- read-word(3ced)
    temp3e <- call 17284 (temp3d, 06)
    temp3f <- (temp3e & 02)
    write-word(3c6b) <- (int16(temp3f) / int16(02))
    temp40 <- read-word(3c6b)
    if (temp40 = 01) is false then
        jump-to: LABEL 68
LABEL 66
    temp41 <- read-word(3c67)
    temp42 <- read-word(3c15)
    if (temp41 = temp42) is true then
        jump-to: LABEL 68
LABEL 67
    write-word(3c83) <- 0c
    write-word(3c6b) <- 00
    jump-to: LABEL 12d
LABEL 68
    temp43 <- read-word(3ced)
    temp44 <- call 17284 (temp43, 07)
    temp03 <- (int16(ff) - int16(temp44))
    temp45 <- call 172a4 (0e, 00)
    temp46 <- call 172a4 (temp45, temp03)
    temp47 <- call 17284 (temp46, 00)
    temp48 <- (int16(temp47) - int16(01))
    write-word(3cc9) <- ffff
    write-word(3ccb) <- ffff
    write-word(3c83) <- 01
    write-word(3c85) <- 01
    write-word(3c6d) <- 00
    temp49 <- (int16(temp46) + int16(01))
    temp4a <- 00
LABEL 69
    if (int16(temp4a) > int16(temp48)) is true then
        jump-to: LABEL 12d
LABEL 6a
    temp03 <- 00
LABEL 6b
    if (int16(temp03) < int16(20)) is false then
        jump-to: LABEL 79
LABEL 6c
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 6e
LABEL 6d
    if (int16(temp03) < int16(20)) is true then
        jump-to: LABEL 6f
LABEL 6e
    discard: call 169c8 (1f, temp03, 1f, 01, 09)
    jump-to: LABEL 70
LABEL 6f
    write-word(3ff7 + (temp03 * 2)) <- 0f
LABEL 70
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 72
LABEL 71
    if (int16(temp03) < int16(20)) is true then
        jump-to: LABEL 73
LABEL 72
    discard: call 169c8 (1f, temp03, 1f, 01, 07)
    jump-to: LABEL 74
LABEL 73
    write-word(3f77 + (temp03 * 2)) <- 01
LABEL 74
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 76
LABEL 75
    if (int16(temp03) < int16(20)) is true then
        jump-to: LABEL 77
LABEL 76
    discard: call 169c8 (1f, temp03, 1f, 01, 08)
    jump-to: LABEL 78
LABEL 77
    write-word(3fb7 + (temp03 * 2)) <- 0f
LABEL 78
    temp03 <- (int16(temp03) + int16(1))
    jump-to: LABEL 6b
LABEL 79
    temp49 <- call 9134 (temp49)
    write-word(3c7f) <- 00
    write-word(3c95) <- 00
    write-word(3c8b) <- 00
    write-word(3c8d) <- 00
    write-word(3c71) <- 00
    write-word(3c73) <- 00
    write-word(3e57) <- 00
    write-word(3cb1) <- 00
    write-word(3c81) <- 01
    temp4b <- read-word(3cef)
    write-word(3ce9) <- (int16(temp4b) + int16(01))
    write-word(3c9f) <- ffff
    write-word(3cb3) <- 00
    temp03 <- 00
    temp4c <- 00
    write-word(3c87) <- 00
LABEL 7a
    temp4d <- read-word(3c87)
    if (int16(temp4d) < int16(00)) is true then
        jump-to: LABEL 7c
LABEL 7b
    temp4e <- read-word(3c87)
    if (int16(temp4e) < int16(20)) is true then
        jump-to: LABEL 7d
LABEL 7c
    temp4f <- read-word(3c87)
    discard: call 169c8 (1d, temp4f, 1f, 01, 09)
    push-SP: 00
    jump-to: LABEL 7e
LABEL 7d
    temp50 <- read-word(3c87)
    push-SP: read-word(3ff7 + (temp50 * 2))
LABEL 7e
    temp51 <- pop-SP
    if (temp51 = 0f) is true then
        jump-to: LABEL b7
LABEL 7f
    write-word(3cd3) <- 00
    temp52 <- read-word(3c87)
    if (int16(temp52) < int16(00)) is true then
        jump-to: LABEL 81
LABEL 80
    temp53 <- read-word(3c87)
    if (int16(temp53) < int16(20)) is true then
        jump-to: LABEL 82
LABEL 81
    temp54 <- read-word(3c87)
    discard: call 169c8 (1d, temp54, 1f, 01, 07)
    push-SP: 00
    jump-to: LABEL 83
LABEL 82
    temp55 <- read-word(3c87)
    push-SP: read-word(3f77 + (temp55 * 2))
LABEL 83
    temp56 <- pop-SP
    if (temp56 = 02) is true then
        jump-to: LABEL 85
LABEL 84
    temp03 <- (int16(temp03) + int16(1))
LABEL 85
    temp57 <- read-word(3c87)
    if (int16(temp57) < int16(00)) is true then
        jump-to: LABEL 87
LABEL 86
    temp58 <- read-word(3c87)
    if (int16(temp58) < int16(20)) is true then
        jump-to: LABEL 88
LABEL 87
    temp59 <- read-word(3c87)
    discard: call 169c8 (1d, temp59, 1f, 01, 07)
    push-SP: 00
    jump-to: LABEL 89
LABEL 88
    temp5a <- read-word(3c87)
    push-SP: read-word(3f77 + (temp5a * 2))
LABEL 89
    temp5b <- pop-SP
    if (temp5b = 01) is false then
        jump-to: LABEL b6
LABEL 8a
    temp5c <- read-word(3c87)
    if (int16(temp5c) < int16(00)) is true then
        jump-to: LABEL 8c
LABEL 8b
    temp5d <- read-word(3c87)
    if (int16(temp5d) < int16(20)) is true then
        jump-to: LABEL 8d
LABEL 8c
    temp5e <- read-word(3c87)
    discard: call 169c8 (1d, temp5e, 1f, 01, 08)
    push-SP: 00
    jump-to: LABEL 8e
LABEL 8d
    temp5f <- read-word(3c87)
    push-SP: read-word(3fb7 + (temp5f * 2))
LABEL 8e
    temp60 <- pop-SP
    if (temp60 = 02) is false then
        jump-to: LABEL 90
LABEL 8f
    temp4c <- 01
LABEL 90
    temp61 <- read-word(3c87)
    if (int16(temp61) < int16(00)) is true then
        jump-to: LABEL 92
LABEL 91
    temp62 <- read-word(3c87)
    if (int16(temp62) < int16(20)) is true then
        jump-to: LABEL 93
LABEL 92
    temp63 <- read-word(3c87)
    discard: call 169c8 (1d, temp63, 1f, 01, 08)
    push-SP: 00
    jump-to: LABEL 94
LABEL 93
    temp64 <- read-word(3c87)
    push-SP: read-word(3fb7 + (temp64 * 2))
LABEL 94
    temp65 <- pop-SP
    if ((temp65 = 04) | (temp65 = 05)) is false then
        jump-to: LABEL b6
LABEL 95
    if (temp03 = 01) is false then
        jump-to: LABEL b6
LABEL 96
    temp66 <- read-word(3c87)
    write-word(3c87) <- (int16(temp66) + int16(1))
    temp67 <- read-word(3c87)
    if (int16(temp67) < int16(00)) is true then
        jump-to: LABEL 98
LABEL 97
    temp68 <- read-word(3c87)
    if (int16(temp68) < int16(20)) is true then
        jump-to: LABEL 99
LABEL 98
    temp69 <- read-word(3c87)
    discard: call 169c8 (1d, temp69, 1f, 01, 07)
    push-SP: 00
    jump-to: LABEL 9a
LABEL 99
    temp6a <- read-word(3c87)
    push-SP: read-word(3f77 + (temp6a * 2))
LABEL 9a
    temp6b <- pop-SP
    if (temp6b = 02) is false then
        jump-to: LABEL b5
LABEL 9b
    temp6c <- read-word(3c87)
    if (int16(temp6c) < int16(00)) is true then
        jump-to: LABEL 9d
LABEL 9c
    temp6d <- read-word(3c87)
    if (int16(temp6d) < int16(20)) is true then
        jump-to: LABEL 9e
LABEL 9d
    temp6e <- read-word(3c87)
    discard: call 169c8 (1d, temp6e, 1f, 01, 07)
    push-SP: 00
    jump-to: LABEL 9f
LABEL 9e
    temp6f <- read-word(3c87)
    push-SP: read-word(3f77 + (temp6f * 2))
LABEL 9f
    temp70 <- pop-SP
    if (temp70 = 02) is false then
        jump-to: LABEL a1
LABEL a0
    temp71 <- read-word(3c87)
    write-word(3c87) <- (int16(temp71) + int16(1))
    jump-to: LABEL 9b
LABEL a1
    temp72 <- read-word(3c87)
    if (int16(temp72) < int16(00)) is true then
        jump-to: LABEL a3
LABEL a2
    temp73 <- read-word(3c87)
    if (int16(temp73) < int16(20)) is true then
        jump-to: LABEL a4
LABEL a3
    temp74 <- read-word(3c87)
    discard: call 169c8 (1d, temp74, 1f, 01, 07)
    push-SP: 00
    jump-to: LABEL a5
LABEL a4
    temp75 <- read-word(3c87)
    push-SP: read-word(3f77 + (temp75 * 2))
LABEL a5
    temp76 <- pop-SP
    if (temp76 = 01) is false then
        jump-to: LABEL b5
LABEL a6
    temp77 <- read-word(3c87)
    if (int16(temp77) < int16(00)) is true then
        jump-to: LABEL a8
LABEL a7
    temp78 <- read-word(3c87)
    if (int16(temp78) < int16(20)) is true then
        jump-to: LABEL a9
LABEL a8
    temp79 <- read-word(3c87)
    discard: call 169c8 (1d, temp79, 1f, 01, 08)
    push-SP: 00
    jump-to: LABEL aa
LABEL a9
    temp7a <- read-word(3c87)
    push-SP: read-word(3fb7 + (temp7a * 2))
LABEL aa
    temp7b <- pop-SP
    if (temp7b = 0) is false then
        jump-to: LABEL b5
LABEL ab
    temp7c <- read-word(3ce9)
    temp7d <- read-word(3ceb)
    if (int16(temp7c) < int16(temp7d)) is false then
        jump-to: LABEL b5
LABEL ac
    temp2f <- call ce34 ()
    if (temp2f = 0) is true then
        jump-to: LABEL b4
LABEL ad
    temp7e <- call 17284 (temp2f, 06)
    temp7f <- (temp7e & 08)
    if (temp7f = 0) is true then
        jump-to: LABEL b4
LABEL ae
    temp2f <- call a30c ()
    if (temp2f = 0) is true then
        jump-to: LABEL b0
LABEL af
    write-word(3c81) <- temp2f
LABEL b0
    temp80 <- read-word(3c69)
    temp81 <- read-word(3c67)
    temp2f <- call aba4 (temp80, temp81, 00)
    if (temp2f = 2710) is false then
        jump-to: LABEL b2
LABEL b1
    jump-to: LABEL 0d
LABEL b2
    if (int16(temp2f) < int16(02)) is true then
        jump-to: LABEL b4
LABEL b3
    write-word(3c9f) <- temp2f
LABEL b4
    jump-to: LABEL ab
LABEL b5
    jump-to: LABEL b7
LABEL b6
    temp82 <- read-word(3c87)
    write-word(3c87) <- (int16(temp82) + int16(1))
    jump-to: LABEL 7a
LABEL b7
    write-word(3cc5) <- 00
    if (temp4c = 0) is true then
        jump-to: LABEL bb
LABEL b8
    temp83 <- read-word(3c93)
    if (temp83 = 01) is false then
        jump-to: LABEL bb
LABEL b9
    temp84 <- read-word(3c9b)
    if (temp84 = 4e) is false then
        jump-to: LABEL bb
LABEL ba
    write-word(3cc5) <- 01
LABEL bb
    write-word(3c7f) <- 00
    write-word(3c95) <- 00
    write-word(3c8b) <- 00
    write-word(3c8d) <- 00
    write-word(3c71) <- 00
    write-word(3c73) <- 00
    write-word(3e57) <- 00
    write-word(3c81) <- 01
    temp85 <- read-word(3cef)
    write-word(3ce9) <- (int16(temp85) + int16(01))
    write-word(3c87) <- 01
LABEL bc
    temp86 <- read-word(3c87)
    if (int16(temp86) < int16(00)) is true then
        jump-to: LABEL be
LABEL bd
    temp87 <- read-word(3c87)
    if (int16(temp87) < int16(20)) is true then
        jump-to: LABEL bf
LABEL be
    temp88 <- read-word(3c87)
    discard: call 169c8 (1f, temp88, 1f, 01, 05)
    jump-to: LABEL c0
LABEL bf
    temp89 <- read-word(3c87)
    write-word(3ef7 + (temp89 * 2)) <- ffff
LABEL c0
    write-word(3cd3) <- 00
    temp8a <- read-word(3c87)
    temp8b <- (int16(temp8a) - int16(01))
    write-word(3dc5) <- temp8b
    temp8c <- read-word(3dc5)
    push-SP: temp8c
    temp8d <- read-word(3dc5)
    if (int16(temp8d) < int16(00)) is true then
        jump-to: LABEL c2
LABEL c1
    temp8e <- read-word(3dc5)
    if (int16(temp8e) < int16(20)) is true then
        jump-to: LABEL c4
LABEL c2
    temp8f <- read-word(3dc5)
    discard: call 169c8 (1d, temp8f, 1f, 01, 09)
    temp90 <- pop-SP
    if (temp90 = 0) is false then
        jump-to: LABEL c3
LABEL c3
    jump-to: LABEL c5
LABEL c4
    temp91 <- pop-SP
    temp01 <- read-word(3ff7 + (temp91 * 2))
LABEL c5
    temp92 <- read-word(3c87)
    if (int16(temp92) < int16(00)) is true then
        jump-to: LABEL c7
LABEL c6
    temp93 <- read-word(3c87)
    if (int16(temp93) < int16(20)) is true then
        jump-to: LABEL c8
LABEL c7
    temp94 <- read-word(3c87)
    discard: call 169c8 (1d, temp94, 1f, 01, 09)
    jump-to: LABEL c9
LABEL c8
    temp95 <- read-word(3c87)
    write-word(3ca9) <- read-word(3ff7 + (temp95 * 2))
LABEL c9
    if (temp01 = 0f) is true then
        jump-to: LABEL eb
LABEL ca
    write-word(3cd1) <- 00
    write-word(3c65) <- 01
    discard: call 9110 (temp01)
    temp96 <- read-word(3c9b)
    if (temp96 = 5d) is false then
        jump-to: LABEL ce
LABEL cb
    temp97 <- read-word(3ca1)
    if (temp97 = 01) is false then
        jump-to: LABEL ce
LABEL cc
    temp98 <- read-word(3ca3)
    if (temp98 = 09) is false then
        jump-to: LABEL ce
LABEL cd
    temp2f <- read-word(3e3b)
    temp99 <- read-word(3ce9)
    write-word(3ce9) <- (int16(temp99) - int16(1))
    temp9a <- read-word(3ce9)
    temp32 <- temp9a
    jump-to: LABEL 56
LABEL ce
    temp9b <- read-word(3c87)
    push-SP: (int16(temp9b) - int16(01))
    temp9c <- read-word(3ca1)
    temp9d <- read-word(3ca3)
    temp9e <- pop-SP
    temp2f <- call a600 (temp9c, temp9d, temp9e, temp01)
LABEL cf
    if (int16(temp2f) < int16(ff38)) is false then
        jump-to: LABEL d1
LABEL d0
    temp9f <- (int16(temp2f) + int16(0100))
    temp2f <- call a600 (01, temp9f)
    jump-to: LABEL cf
LABEL d1
    write-word(3cd1) <- 00
    if (temp2f = 0) is false then
        jump-to: LABEL d7
LABEL d2
    tempa0 <- read-word(3ca1)
    if (tempa0 = 02) is true then
        jump-to: LABEL d6
LABEL d3
    tempa1 <- read-word(3ca1)
    if (tempa1 = 01) is false then
        jump-to: LABEL d5
LABEL d4
    tempa2 <- read-word(3ca3)
    if (tempa2 = 09) is true then
        jump-to: LABEL d6
LABEL d5
    tempa3 <- read-word(3c93)
    write-word(3c93) <- (int16(tempa3) - int16(1))
LABEL d6
    temp2f <- 01
    jump-to: LABEL e6
LABEL d7
    if (int16(temp2f) < int16(00)) is false then
        jump-to: LABEL d9
LABEL d8
    temp2f <- 00
    jump-to: LABEL e6
LABEL d9
    if (temp2f = 2710) is true then
        jump-to: LABEL e6
LABEL da
    if (temp2f = 01) is false then
        jump-to: LABEL df
LABEL db
    tempa4 <- read-word(3c8d)
    if (tempa4 = 0) is false then
        jump-to: LABEL dd
LABEL dc
    tempa5 <- read-word(3c75)
    write-word(3c8f) <- tempa5
    jump-to: LABEL de
LABEL dd
    tempa6 <- read-word(3c75)
    write-word(3c91) <- tempa6
LABEL de
    tempa7 <- read-word(3c8d)
    write-word(3c8d) <- (int16(tempa7) + int16(1))
    temp2f <- 01
LABEL df
    if (temp2f = 02) is false then
        jump-to: LABEL e1
LABEL e0
    temp2f <- 00
LABEL e1
    tempa8 <- read-word(3c8b)
    tempa9 <- (int16(tempa8) + int16(02))
    discard: call 17340 (temp00, tempa9, temp2f)
    tempaa <- read-word(3c8b)
    write-word(3c8b) <- (int16(tempaa) + int16(1))
    tempab <- read-word(3c87)
    if (int16(tempab) < int16(00)) is true then
        jump-to: LABEL e3
LABEL e2
    tempac <- read-word(3c87)
    if (int16(tempac) < int16(20)) is true then
        jump-to: LABEL e4
LABEL e3
    tempad <- read-word(3c87)
    discard: call 169c8 (1f, tempad, 1f, 01, 05)
    jump-to: LABEL e5
LABEL e4
    tempae <- read-word(3c87)
    write-word(3ef7 + (tempae * 2)) <- temp2f
LABEL e5
    temp2f <- 01
LABEL e6
    if (temp2f = 2710) is false then
        jump-to: LABEL e8
LABEL e7
    jump-to: LABEL 0d
LABEL e8
    if (temp2f = 0) is false then
        jump-to: LABEL ea
LABEL e9
    jump-to: LABEL 124
LABEL ea
    jump-to: LABEL 123
LABEL eb
    tempaf <- read-word(3ce9)
    tempb0 <- read-word(3ceb)
    if (int16(tempaf) > int16(tempb0)) is true then
        jump-to: LABEL fc
LABEL ec
    temp2f <- call ce34 ()
    tempb1 <- temp2f
    if (((tempb1 = 6664) | (tempb1 = 6664)) | (tempb1 = 6664)) is true then
        jump-to: LABEL ee
LABEL ed
    if (temp2f = 5332) is false then
        jump-to: LABEL ef
LABEL ee
    write-word(3cf7) <- 01
    tempb2 <- read-word(3ce9)
    write-word(3cf9) <- (int16(tempb2) - int16(01))
    jump-to: LABEL fc
LABEL ef
    temp4c <- 00
LABEL f0
    if (int16(temp4c) < int16(20)) is false then
        jump-to: LABEL fb
LABEL f1
    if (int16(temp4c) < int16(00)) is true then
        jump-to: LABEL f3
LABEL f2
    if (int16(temp4c) < int16(20)) is true then
        jump-to: LABEL f4
LABEL f3
    discard: call 169c8 (1d, temp4c, 1f, 01, 05)
    push-SP: 00
    jump-to: LABEL f5
LABEL f4
    push-SP: read-word(3ef7 + (temp4c * 2))
LABEL f5
    if (int16(temp4c) < int16(00)) is true then
        jump-to: LABEL f7
LABEL f6
    if (int16(temp4c) < int16(20)) is true then
        jump-to: LABEL f9
LABEL f7
    discard: call 169c8 (1f, temp4c, 1f, 01, 06)
    tempb3 <- pop-SP
    if (tempb3 = 0) is false then
        jump-to: LABEL f8
LABEL f8
    jump-to: LABEL fa
LABEL f9
    tempb4 <- pop-SP
    write-word(3f37 + (temp4c * 2)) <- tempb4
LABEL fa
    temp4c <- (int16(temp4c) + int16(1))
    jump-to: LABEL f0
LABEL fb
    tempb5 <- read-word(3c87)
    write-word(3c89) <- tempb5
    write-word(3c81) <- 02
    jump-to: LABEL 124
LABEL fc
    tempb6 <- read-word(3c8b)
    if (int16(tempb6) < int16(01)) is true then
        jump-to: LABEL 100
LABEL fd
    tempb7 <- call 172a4 (temp00, 02)
    if (tempb7 = 0) is false then
        jump-to: LABEL 100
LABEL fe
    tempb8 <- call 172a4 (temp00, 03)
    temp2f <- call baa4 (tempb8)
    if (temp2f = 0) is true then
        jump-to: LABEL 100
LABEL ff
    write-word(3c81) <- temp2f
    tempb9 <- read-word(3c9b)
    discard: call 17340 (temp00, 00, tempb9)
    jump-to: LABEL 124
LABEL 100
    tempba <- read-word(3c8b)
    if (int16(tempba) < int16(02)) is true then
        jump-to: LABEL 104
LABEL 101
    tempbb <- call 172a4 (temp00, 03)
    if (tempbb = 0) is false then
        jump-to: LABEL 104
LABEL 102
    tempbc <- call 172a4 (temp00, 02)
    temp2f <- call baa4 (tempbc)
    if (temp2f = 0) is true then
        jump-to: LABEL 104
LABEL 103
    write-word(3c81) <- temp2f
    jump-to: LABEL 124
LABEL 104
    tempbd <- read-word(3cc5)
    if (tempbd = 02) is false then
        jump-to: LABEL 107
LABEL 105
    tempbe <- call 172a4 (temp00, 02)
    tempbf <- read-word(3c67)
    if (tempbe = tempbf) is false then
        jump-to: LABEL 107
LABEL 106
    write-word(3c83) <- 11
    jump-to: LABEL 12d
LABEL 107
    write-word(3cf3) <- 00
    tempc0 <- read-word(3c95)
    if (tempc0 = 0) is true then
        jump-to: LABEL 109
LABEL 108
    print: "("
    tempc1 <- read-word(3c95)
    discard: call c268 (tempc1)
    print: ")\n"
LABEL 109
    tempc2 <- read-word(3c9b)
    discard: call 17340 (temp00, 00, tempc2)
    tempc3 <- read-word(3c8b)
    discard: call 17340 (temp00, 01, tempc3)
    tempc4 <- read-word(3c9d)
    if (tempc4 = 0) is true then
        jump-to: LABEL 10d
LABEL 10a
    tempc5 <- read-word(3c8b)
    if (tempc5 = 02) is false then
        jump-to: LABEL 10d
LABEL 10b
    temp03 <- call 172a4 (temp00, 02)
    tempc6 <- call 172a4 (temp00, 03)
    discard: call 17340 (temp00, 02, tempc6)
    discard: call 17340 (temp00, 03, temp03)
    tempc7 <- read-word(3c8d)
    if (tempc7 = 02) is false then
        jump-to: LABEL 10d
LABEL 10c
    tempc8 <- read-word(3c8f)
    tempc9 <- read-word(3c91)
    write-word(3c8f) <- tempc9
    write-word(3c91) <- tempc8
LABEL 10d
    tempca <- read-word(3c8b)
    if (int16(tempca) > int16(00)) is false then
        jump-to: LABEL 110
LABEL 10e
    tempcb <- call 172a4 (temp00, 02)
    if (int16(tempcb) < int16(02)) is true then
        jump-to: LABEL 110
LABEL 10f
    tempcc <- call 172a4 (temp00, 02)
    discard: call d444 (tempcc)
LABEL 110
    tempcd <- read-word(3c7f)
    if (tempcd = 0) is true then
        jump-to: LABEL 120
LABEL 111
    tempce <- read-word(3c67)
    tempcf <- read-word(3c15)
    if (tempce = tempcf) is false then
        jump-to: LABEL 120
LABEL 112
    write-word(3c4d) <- 4e
    tempd0 <- read-word(3c7f)
    temp03 <- call e044 (tempd0, 49)
    if (int16(temp03) > int16(02)) is false then
        jump-to: LABEL 114
LABEL 113
    write-word(3c83) <- 06
    jump-to: LABEL 12d
LABEL 114
    if (int16(temp03) < int16(02)) is false then
        jump-to: LABEL 120
LABEL 115
    if (temp03 = 01) is true then
        jump-to: LABEL 117
LABEL 116
    tempd1 <- read-word(3c7f)
    discard: call 13a88 (1007, 1a, tempd1)
LABEL 117
    write-word(3c7b) <- 01
    temp03 <- 00
LABEL 118
    if (int16(temp03) < int16(08)) is false then
        jump-to: LABEL 11f
LABEL 119
    push-SP: call 172a4 (temp00, temp03)
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 11b
LABEL 11a
    if (int16(temp03) < int16(10)) is true then
        jump-to: LABEL 11d
LABEL 11b
    discard: call 169c8 (1f, temp03, 0f, 01, 04)
    tempd2 <- pop-SP
    if (tempd2 = 0) is false then
        jump-to: LABEL 11c
LABEL 11c
    jump-to: LABEL 11e
LABEL 11d
    tempd3 <- pop-SP
    write-word(3ed7 + (temp03 * 2)) <- tempd3
LABEL 11e
    temp03 <- (int16(temp03) + int16(1))
    jump-to: LABEL 118
LABEL 11f
    discard: call 17340 (temp00, 00, 4e)
    discard: call 17340 (temp00, 01, 01)
    tempd4 <- read-word(3c7f)
    discard: call 17340 (temp00, 02, tempd4)
LABEL 120
    tempd5 <- read-word(3cf7)
    if (tempd5 = 01) is false then
        jump-to: LABEL 122
LABEL 121
    tempd6 <- read-word(3cf9)
    write-word(3ce9) <- tempd6
    jump-to: LABEL 192
LABEL 122
    return: 1
LABEL 123
    tempd7 <- read-word(3c87)
    write-word(3c87) <- (int16(tempd7) + int16(1))
    jump-to: LABEL bc
LABEL 124
    tempd8 <- read-word(3c81)
    tempd9 <- read-word(3c83)
    if (int16(tempd8) > int16(tempd9)) is false then
        jump-to: LABEL 126
LABEL 125
    tempda <- read-word(3c81)
    write-word(3c83) <- tempda
LABEL 126
    tempdb <- read-word(3c81)
    if (tempdb = 12) is true then
        jump-to: LABEL 129
LABEL 127
    tempdc <- read-word(3c81)
    tempdd <- read-word(3c85)
    if (int16(tempdc) > int16(tempdd)) is false then
        jump-to: LABEL 129
LABEL 128
    tempde <- read-word(3c81)
    write-word(3c85) <- tempde
LABEL 129
    tempdf <- read-word(3cc5)
    if (tempdf = 02) is false then
        jump-to: LABEL 12c
LABEL 12a
    tempe0 <- read-word(3c81)
    if (tempe0 = 11) is false then
        jump-to: LABEL 12c
LABEL 12b
    jump-to: LABEL 12d
LABEL 12c
    temp4a <- (int16(temp4a) + int16(1))
    jump-to: LABEL 69
LABEL 12d
    tempe1 <- read-word(3c83)
    write-word(3c81) <- tempe1
    tempe2 <- read-word(3c67)
    tempe3 <- read-word(3c15)
    if (tempe2 = tempe3) is true then
        jump-to: LABEL 133
LABEL 12e
    tempe4 <- read-word(3cf1)
    if (tempe4 = 0) is true then
        jump-to: LABEL 130
LABEL 12f
    tempe5 <- read-word(3cf1)
    write-word(3cef) <- tempe5
    jump-to: LABEL 0e
LABEL 130
    tempe6 <- read-word(3cef)
    write-word(3ce9) <- tempe6
    write-word(3c71) <- call ce34 ()
    tempe7 <- read-word(3c71)
    if (tempe7 = 5332) is false then
        jump-to: LABEL 132
LABEL 131
    write-word(3c71) <- call ce34 ()
    tempe8 <- read-word(3cef)
    write-word(3cef) <- (int16(tempe8) + int16(1))
LABEL 132
    tempe9 <- read-word(3cef)
    write-word(3c73) <- call cf30 (tempe9)
    discard: call 17340 (temp00, 00, 1009)
    discard: call 17340 (temp00, 01, 02)
    discard: call 17340 (temp00, 02, 01)
    tempea <- read-word(3c71)
    write-word(3c8f) <- tempea
    tempeb <- read-word(3c67)
    discard: call 17340 (temp00, 03, tempeb)
    tempec <- read-word(3cef)
    write-word(3c77) <- tempec
    temped <- read-word(3ceb)
    tempee <- read-word(3c77)
    tempef <- (int16(temped) - int16(tempee))
    write-word(3c79) <- (int16(tempef) + int16(01))
    return: 1
LABEL 133
    tempf0 <- read-word(3c81)
    tempf1 <- call 15f94 (tempf0)
    if (tempf1 = 0) is true then
        jump-to: LABEL 135
LABEL 134
    jump-to: LABEL 0c
LABEL 135
    tempf2 <- read-word(3ccd)
    write-word(3cc9) <- tempf2
    tempf3 <- read-word(3ccf)
    write-word(3ccb) <- tempf3
    tempf4 <- read-word(3c81)
    if (tempf4 = 01) is false then
        jump-to: LABEL 137
LABEL 136
    discard: call 13a88 (1007, 1b)
    write-word(3cf3) <- 01
LABEL 137
    tempf5 <- read-word(3c81)
    if (tempf5 = 02) is false then
        jump-to: LABEL 145
LABEL 138
    discard: call 13a88 (1007, 1c)
    temp4c <- 00
LABEL 139
    if (int16(temp4c) < int16(20)) is false then
        jump-to: LABEL 144
LABEL 13a
    if (int16(temp4c) < int16(00)) is true then
        jump-to: LABEL 13c
LABEL 13b
    if (int16(temp4c) < int16(20)) is true then
        jump-to: LABEL 13d
LABEL 13c
    discard: call 169c8 (1d, temp4c, 1f, 01, 06)
    push-SP: 00
    jump-to: LABEL 13e
LABEL 13d
    push-SP: read-word(3f37 + (temp4c * 2))
LABEL 13e
    if (int16(temp4c) < int16(00)) is true then
        jump-to: LABEL 140
LABEL 13f
    if (int16(temp4c) < int16(20)) is true then
        jump-to: LABEL 142
LABEL 140
    discard: call 169c8 (1f, temp4c, 1f, 01, 05)
    tempf6 <- pop-SP
    if (tempf6 = 0) is false then
        jump-to: LABEL 141
LABEL 141
    jump-to: LABEL 143
LABEL 142
    tempf7 <- pop-SP
    write-word(3ef7 + (temp4c * 2)) <- tempf7
LABEL 143
    temp4c <- (int16(temp4c) + int16(1))
    jump-to: LABEL 139
LABEL 144
    tempf8 <- read-word(3c89)
    write-word(3c87) <- tempf8
    discard: call c268 (00)
    discard: call 13a88 (1007, 38)
LABEL 145
    tempf9 <- read-word(3c81)
    if (tempf9 = 03) is false then
        jump-to: LABEL 147
LABEL 146
    discard: call 13a88 (1007, 1d)
LABEL 147
    tempfa <- read-word(3c81)
    if (tempfa = 04) is false then
        jump-to: LABEL 149
LABEL 148
    discard: call 13a88 (1007, 1e)
    tempfb <- read-word(3cf5)
    write-word(3cf3) <- tempfb
LABEL 149
    tempfc <- read-word(3c81)
    if (tempfc = 05) is false then
        jump-to: LABEL 14b
LABEL 14a
    discard: call 13a88 (1007, 1f)
LABEL 14b
    tempfd <- read-word(3c81)
    if (tempfd = 06) is false then
        jump-to: LABEL 14d
LABEL 14c
    discard: call 13a88 (1007, 20)
    tempfe <- read-word(3cf5)
    write-word(3cf3) <- tempfe
LABEL 14d
    tempff <- read-word(3c81)
    if (tempff = 07) is false then
        jump-to: LABEL 14f
LABEL 14e
    discard: call 13a88 (1007, 21)
LABEL 14f
    temp100 <- read-word(3c81)
    if (temp100 = 08) is false then
        jump-to: LABEL 151
LABEL 150
    discard: call 13a88 (1007, 22)
LABEL 151
    temp101 <- read-word(3c81)
    if (temp101 = 09) is false then
        jump-to: LABEL 153
LABEL 152
    discard: call 13a88 (1007, 23)
LABEL 153
    temp102 <- read-word(3c81)
    if (temp102 = 0a) is false then
        jump-to: LABEL 155
LABEL 154
    discard: call 13a88 (1007, 24)
LABEL 155
    temp103 <- read-word(3c81)
    if (temp103 = 0b) is false then
        jump-to: LABEL 157
LABEL 156
    discard: call 13a88 (1007, 25)
LABEL 157
    temp104 <- read-word(3c81)
    if (temp104 = 0c) is false then
        jump-to: LABEL 159
LABEL 158
    discard: call 13a88 (1007, 26)
LABEL 159
    temp105 <- read-word(3c81)
    if (temp105 = 0d) is false then
        jump-to: LABEL 15b
LABEL 15a
    discard: call 13a88 (1007, 27)
LABEL 15b
    temp106 <- read-word(3c81)
    if (temp106 = 0e) is false then
        jump-to: LABEL 15f
LABEL 15c
    temp107 <- read-word(3ccb)
    if (temp107 = ffff) is false then
        jump-to: LABEL 15e
LABEL 15d
    discard: call 13a88 (1007, 23)
    jump-to: LABEL 15f
LABEL 15e
    discard: call 13a88 (1007, 28)
LABEL 15f
    temp108 <- read-word(3c81)
    if (temp108 = 0f) is false then
        jump-to: LABEL 161
LABEL 160
    discard: call 13a88 (1007, 29)
LABEL 161
    temp109 <- read-word(3c81)
    if (temp109 = 10) is false then
        jump-to: LABEL 163
LABEL 162
    temp10a <- read-word(3caf)
    discard: call 13a88 (1007, 2a, temp10a)
LABEL 163
    temp10b <- read-word(3c81)
    if (temp10b = 11) is false then
        jump-to: LABEL 18b
LABEL 164
    temp10c <- call 172a4 (temp00, 00)
    if (temp10c = 38) is false then
        jump-to: LABEL 187
LABEL 165
    temp10d <- call 172a4 (temp00, 03)
    temp10e <- call 1682c (temp10d, 02)
    if (temp10e = 0) is true then
        jump-to: LABEL 187
LABEL 166
    write-word(3c53) <- call 172a4 (temp00, 03)
    temp10f <- read-word(3c53)
    if (int16(01) > int16(temp10f)) is true then
        jump-to: LABEL 168
LABEL 167
    temp110 <- read-word(3c53)
    if (int16(temp110) > int16(0114)) is false then
        jump-to: LABEL 169
LABEL 168
    temp111 <- read-word(3c53)
    discard: call 169c8 (03, temp111)
    jump-to: LABEL 16b
LABEL 169
    temp112 <- read-word(3c53)
    if (((read-byte(((temp112 - 1) * e) + 188) & 0080) <> 0) = 1) is false then
        jump-to: LABEL 16b
LABEL 16a
    temp113 <- read-word(3c53)
    discard: call 13a88 (4e, 06, temp113)
    jump-to: LABEL 187
LABEL 16b
    temp114 <- read-word(3c53)
    if (int16(01) > int16(temp114)) is true then
        jump-to: LABEL 16d
LABEL 16c
    temp115 <- read-word(3c53)
    if (int16(temp115) > int16(0114)) is false then
        jump-to: LABEL 16e
LABEL 16d
    temp116 <- read-word(3c53)
    discard: call 169c8 (03, temp116)
    jump-to: LABEL 16f
LABEL 16e
    temp117 <- read-word(3c53)
    if (((read-byte(((temp117 - 1) * e) + 188) & 0008) <> 0) = 1) is true then
        jump-to: LABEL 174
LABEL 16f
    temp118 <- read-word(3c53)
    if (int16(01) > int16(temp118)) is true then
        jump-to: LABEL 171
LABEL 170
    temp119 <- read-word(3c53)
    if (int16(temp119) > int16(0114)) is false then
        jump-to: LABEL 172
LABEL 171
    temp11a <- read-word(3c53)
    discard: call 169c8 (03, temp11a)
    jump-to: LABEL 173
LABEL 172
    temp11b <- read-word(3c53)
    if (((read-byte((((temp11b - 1) * e) + 188) + 2) & 0008) <> 0) = 1) is true then
        jump-to: LABEL 174
LABEL 173
    temp11c <- read-word(3c53)
    discard: call 13a88 (1c, 02, temp11c)
    jump-to: LABEL 187
LABEL 174
    temp11d <- read-word(3c53)
    if (int16(01) > int16(temp11d)) is true then
        jump-to: LABEL 176
LABEL 175
    temp11e <- read-word(3c53)
    if (int16(temp11e) > int16(0114)) is false then
        jump-to: LABEL 177
LABEL 176
    temp11f <- read-word(3c53)
    discard: call 169c8 (03, temp11f)
    jump-to: LABEL 17d
LABEL 177
    temp120 <- read-word(3c53)
    if (((read-byte(((temp120 - 1) * e) + 188) & 0008) <> 0) = 1) is false then
        jump-to: LABEL 17d
LABEL 178
    temp121 <- read-word(3c53)
    if (int16(01) > int16(temp121)) is true then
        jump-to: LABEL 17a
LABEL 179
    temp122 <- read-word(3c53)
    if (int16(temp122) > int16(0114)) is false then
        jump-to: LABEL 17b
LABEL 17a
    temp123 <- read-word(3c53)
    discard: call 169c8 (03, temp123)
    jump-to: LABEL 17c
LABEL 17b
    temp124 <- read-word(3c53)
    if (((read-byte((((temp124 - 1) * e) + 188) + 1) & 0002) <> 0) = 1) is true then
        jump-to: LABEL 17d
LABEL 17c
    temp125 <- read-word(3c53)
    discard: call 13a88 (4e, 09, temp125)
    jump-to: LABEL 187
LABEL 17d
    temp126 <- read-word(3c53)
    if (int16(05) > int16(temp126)) is true then
        jump-to: LABEL 180
LABEL 17e
    temp127 <- read-word(3c53)
    if (int16(temp127) > int16(0114)) is true then
        jump-to: LABEL 180
LABEL 17f
    temp128 <- read-word(3c53)
    if (read-word((((temp128 - 1) * e) + 188) + 6) = 01) is false then
        jump-to: LABEL 181
LABEL 180
    temp129 <- read-word(3c53)
    discard: call 169c8 (09, temp129)
    write-word(3dc5) <- 02
    jump-to: LABEL 182
LABEL 181
    temp12a <- read-word(3c53)
    write-word(3dc5) <- temp12a
LABEL 182
    write-word(3dc7) <- 00
    temp12b <- read-word(3dc5)
    push-SP: read-word((((temp12b - 1) * e) + 188) + a)
    if (read-word((((temp12b - 1) * e) + 188) + a) <> 0) is false then
        jump-to: LABEL 184
LABEL 183
    temp12c <- read-word(3dc7)
    write-word(3dc7) <- (int16(temp12c) + int16(1))
    temp12d <- pop-SP
    push-SP: read-word((((temp12d - 1) * e) + 188) + 8)
    if (read-word((((temp12d - 1) * e) + 188) + 8) <> 0) is true then
        jump-to: LABEL 183
LABEL 184
    temp12e <- pop-SP
    write-word(3dc5) <- temp12e
    temp12f <- read-word(3dc7)
    if (temp12f = 0) is false then
        jump-to: LABEL 186
LABEL 185
    temp130 <- read-word(3c53)
    discard: call 13a88 (40, 06, temp130)
    jump-to: LABEL 187
LABEL 186
    discard: call 17340 (temp00, 00, 00)
LABEL 187
    temp131 <- call 172a4 (temp00, 00)
    if (temp131 = 38) is true then
        jump-to: LABEL 18b
LABEL 188
    temp132 <- read-word(3cad)
    if (temp132 = 64) is false then
        jump-to: LABEL 18a
LABEL 189
    discard: call 13a88 (1007, 2b)
    jump-to: LABEL 18b
LABEL 18a
    discard: call 13a88 (1007, 2c)
LABEL 18b
    temp133 <- read-word(3c81)
    if (temp133 = 12) is false then
        jump-to: LABEL 191
LABEL 18c
    write-word(3cd7) <- 03
    temp134 <- read-word(3cd5)
    if (temp134 = 0) is false then
        jump-to: LABEL 18e
LABEL 18d
    push-SP: 0
    jump-to: LABEL 18f
LABEL 18e
    push-SP: call (temp134 * 4) ()
LABEL 18f
    temp135 <- pop-SP
    if (temp135 = ffff) is false then
        jump-to: LABEL 191
LABEL 190
    temp136 <- read-word(3c85)
    write-word(3c83) <- temp136
    jump-to: LABEL 12d
LABEL 191
    jump-to: LABEL 0c
LABEL 192
    temp137 <- read-word(3ce9)
    temp138 <- read-word(3ceb)
    if (int16(temp137) > int16(temp138)) is true then
        return: 1
LABEL 193
    temp03 <- call ce34 ()
    temp139 <- temp03
    if (((temp139 = 6664) | (temp139 = 6664)) | (temp139 = 6664)) is true then
        jump-to: LABEL 195
LABEL 194
    if (temp03 = 5332) is false then
        jump-to: LABEL 1a5
LABEL 195
    temp13a <- read-word(3ce9)
    temp13b <- read-word(3ceb)
    if (int16(temp13a) > int16(temp13b)) is false then
        jump-to: LABEL 197
LABEL 196
    write-word(3cf7) <- 00
    return: 1
LABEL 197
    temp13c <- read-word(3cef)
    temp03 <- call cec8 (temp13c)
    temp13d <- read-word(3ce9)
    temp32 <- call cec8 (temp13d)
LABEL 198
    if (int16(temp03) < int16(temp32)) is false then
        jump-to: LABEL 19a
LABEL 199
    discard: call 172c8 (temp03, 00, 20)
    temp03 <- (int16(temp03) + int16(1))
    jump-to: LABEL 198
LABEL 19a
    temp03 <- call ce34 ()
    temp13e <- temp03
    if (((temp13e = 4f03) | (temp13e = 5830)) | (temp13e = 4f03)) is false then
        jump-to: LABEL 1a4
LABEL 19b
    temp13f <- read-word(3ce9)
    temp140 <- (int16(temp13f) - int16(02))
    temp141 <- call cec8 (temp140)
    temp03 <- (int16(temp141) - int16(41b7))
    temp142 <- read-word(3ce9)
    temp143 <- read-word(3ceb)
    if (int16(temp142) > int16(temp143)) is false then
        jump-to: LABEL 19d
LABEL 19c
    temp32 <- 77
    jump-to: LABEL 19e
LABEL 19d
    temp144 <- read-word(3ce9)
    temp145 <- call cec8 (temp144)
    temp32 <- (int16(temp145) - int16(41b7))
LABEL 19e
    if (int16(temp03) < int16(temp32)) is false then
        jump-to: LABEL 1a4
LABEL 19f
    if (int16(temp03) < int16(00)) is true then
        jump-to: LABEL 1a1
LABEL 1a0
    if (int16(temp03) < int16(7b)) is true then
        jump-to: LABEL 1a2
LABEL 1a1
    discard: call 169c8 (1e, temp03, 7a, 00, 11)
    jump-to: LABEL 1a3
LABEL 1a2
    write-byte(432f + temp03) <- 20
LABEL 1a3
    temp03 <- (int16(temp03) + int16(1))
    jump-to: LABEL 19e
LABEL 1a4
    discard: call 9248 (41b7, 4232)
    write-word(3cf7) <- 01
    return: 1
LABEL 1a5
    write-word(3c83) <- 02
    jump-to: LABEL 12d
]]>

        TestBinder(Advent, &H9524, expected)
    End Sub

#End Region

End Module