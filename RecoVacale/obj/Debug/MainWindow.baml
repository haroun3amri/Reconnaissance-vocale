   M S B A M L   `   `   `  ����E  ARecoVacale, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:RecoVacale
RecoVacale  5   	       RecoVacale.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:RecoVacale     5   	   U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  Smart_Sound��5   	      MaterialDesignBody#���   5   	   $��Regular"�5	   	   $��13(�5
   	   &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=�5   	      TextRenderingMode$
 Auto=�5   	     MaterialDesignPaper#���  5   	     MaterialDesignFont#���  5   	    � Title$ Smart Sound��5   	   $��877.9��6   $��1337.75��6,   .��5      ]� -   5         ]�Name$ D1��5      $��	0,0,0,-98q�6   .+�5   
   o�  o� 
IsMainMenu . $	��Top=�6!   .@�5      m� $
��Home��6    m� Icon 5      '  !MaterialDesignThemes.Wpf.PackIcon  5      �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$
 Home=�6.   5      m� 5"      -   5         m�Name$ DB��5"      $��Archive��6#    5#        5$      $ database=�6.   5'      m� 5)      -   5        $��Sequences Filtrées��5)       5*        5+      $ Filter=�6.   5-      m� 5/      $��Player��6    50        51      $ MusicBox=�6.   54      55      #  MaterialDesignThemes.Wpf.Card  57   
   $��	40 4 20 0q�6   $	��400��61   $	��518��6=   .��58      � 	 � RowDefinitions	 59      �� 5:      $	��140 �6$   �� 5;      $��* �6$   �� 5<      $
��Auto �6$   .+�5?      �� -   5        $��0��5?       , (MaterialDesignFloatingActionAccentButton#��[ 6&   $��Right=�5@      $��Bottom=�65   $��
0 0 16 -20q�5A      .��5B        $ 	MusicNote=�6.   5C      �� 5D      -   5        $��0��5D      #��[ 6&   $��Right=�5E      $��Bottom=�65   $��0,0,264,312q�5F      $��2��6.   .��5G        $ DatabasePlus=�6.   5H      �� 5J      -   5        $��	lblStatus��5J   %   $��0��6   $��Not playing...��66   $��Center=�6O   $��5q�6s   �� 5K      -   5        $��1��5K      $��Right=�5L      $��Bottom=�65   $��
0,0,16,193q�5M      .��5O        $
 Stop=�6.   5P      �� 5Q      -	   5        $��1��5Q      $��Center=�5R      $��Bottom=�66   $��148,0,144,193q�5S      .��5U        $ Pause=�6.   5V      �� 5W      -
   5        $��1��5W      $
��Left=�5X      $��Bottom=�64   $��
20,0,0,193q�5Y      .��5[        $
 Play=�6.   5\      �� 5^      -   5        
 ��Name$
 Screen��5^      $��
6,155,8,10q�6.   $��1��6B   ���	#FF6A68686O   �� 5_      $��1��6   $��8 24 8 0q�6*   .+�5`      �� $
��Bold"�6    Importer fichier audio6J   �� 5a      $
��Wrap=�6    $��Center=�64   :8Ajouter un fichier Wav Mp3 .. depuis votre espace local.6�   5b      �� 5c      $��Right=�6   $��2��69    �� Orientation$ 
Horizontal=�6F   $��8q�6_   .+�5f      '  !MaterialDesignThemes.Wpf.PopupBox  $��2 0 2 0q�6/      PopupContent. 5g      �� .+�5h      �� $
��More��6%   �� 5i      $��Options��6%   5j      5k      5n      �� 5o      -   5        $��FileNameTextBox��5o   S   $��32��6   $
��Left=�6&   $��6,10,0,0q�6A   $	��Top=�5p      $	��393��6*   �� 5q      -   5        $��State��5q   I   $
��Left=�6   $��
132,46,0,0q�65    �� TextWrapping$
 Wrap=�6W   $��
Not Loaded��6k   $	��Top=�6}   5r      5s        5t   
   $��	10 4 20 0q�6   $	��400��61   $	��518��6=   .��5u      � 	 5v      �� 5w      $	��140 �6$   �� 5x      $��* �6$   �� 5y      $
��Auto �6$   .+�5|      �� $��0��6   #��[ 6&   $��Right=�5}      $��Bottom=�65   $��
0 0 16 -20q�5~      .��5        $ 
Microphone=�6.   5�      �� 5�      $��1��6   $��8 24 8 0q�6*   .+�5�      �� $
��Bold"�6    Enregistrer un fichier audio6P   �� 5�      $
��Wrap=�6    $��Center=�64   31Ouvrir le microphone et creer votre fichier audio6�   5�      �� 5�      $��Right=�6   $��2��69   $ 
Horizontal=�6F   $��8q�6_   .+�5�        $��2 0 2 0q�6/   . 5�      �� .+�5�      �� $
��More��6%   �� 5�      $��Options��6%   5�      5�      5�      5�      5�        5�   
   $��	10 4 20 0q�6   $	��400��61   $	��518��6=   .��5�      � 	 5�      �� 5�      $	��140 �6$   �� 5�      $��* �6$   �� 5�      $
��Auto �6$   .+�5�      �� -   5        $��	LookedFor��5�   (   $��0��6   $��1��6:    % !MaterialDesignFloatingHintTextBox#��[ 6J   $��Rechercher sequence��6�   $��0 8 0 8q�5�      .��6#   )  #MaterialDesignThemes.Wpf.HintAssist   Hint 5�      �� 5�      $ 
Horizontal=�6%   $��-2 0 0 0q�6>   .+�5�        $ AccountSearch=�66   �� 5�      64Tappez la sequence à rechercher dans la piste audio6]   5�      .��5�   6   5�      �� 5�      -   5         + 'MaterialDesignFloatingActionLightButton#��[ 5�      $��0 0 8 0q�5�      $��Right=�6*    � ToolTip$- 'MaterialDesignFloatingActionLightButton��5�      .��5�        $ AccountSearch=�6.   $��24��6C   $��24��6O   5�      �� 5�      -   5        $
 Screen2��5�      $��1��60   ���	#FF6A6868$��10,14,129,293q�6T   �� 5�      -   5        $
 Screen3��5�      $��1��60   ���	#FF6A6868$��254,15,10,292q�6T   �� 5�      #��[ 6   $��0,116,8,202q�5�      $��Right=�6.   $- 'MaterialDesignFloatingActionLightButton��5�      $��1��6K   .��5�        $ Filter=�6.   $��24��6<   $��24��6H   5�      �� 5�      $��1��6   $ Virtualisation��6(   $��30,185,22,161q�6X   .@�5�      ��  �� 
IsSelected . .��65    Filtre 1 (Utilisé Par Defaut)6T   �� 5�      .��6$   
Filtre 26.   �� 5�      .��6#   
Filtre 36-   5�      5�      5�      &   System.Windows.Controls.DataGrid  5�   
   -   5        $��grdEmployee��5�   ,   $��Bottom=�6   $��
-24,0,24,0q�6?   5�      5�      