   M S B A M L   `   `   `  ����B  >planner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:plannerplanner  5      O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem 5	          planner.createCard   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:planner     5      X TXceed.Wpf.Toolkit, Version=3.4.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5      7xcad,http://schemas.xceed.com/wpf/xaml/avalondock  5      3system&clr-namespace:System;assembly=mscorlib  5	      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5
      
�������
���   �  � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $h bpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.PopupBox.xaml?�6%   �� 5      $i cpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml?�6%   �� 5      $j dpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.DatePicker.xaml?�6%   �� 5      $o ipack://application:,,,/MaterialDesignColors;component/Themes/MaterialDesignColor.Green.Named.Primary.xaml?�6%   %    5      .��5      � $	��540��6   $
��1010��6   $��2q�6%    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5       � ColumnDefinitions 5   
   �� 5       $��* �6   �� 5!      .+�5#   
   �� $��1��6    �� Orientation$ 
Horizontal=�5$      .+�5%      �� $��Center=�5'      $��24(�5(      ��5&      �� *Date+ �� StringFormat$ {0:yyyy-MM-dd HH:mm:ss}��5(      5)      �� 5*   
   $��0��6   .+�5+      �  5,      �� 5-      $	��100 �6'   �� 5.      .+�50      �� $��0��6      createHeader#���   6(   $��15(�6Q   $��5,10,0,5q�6_   $��Center=�6q   $
��Left=�6�   4  .Xceed.Wpf.Toolkit.Primitives.ValueRangeTextBox  51      -   5        $��	headerBox��51   )   $��Center=�6:   $��15(�6\   $��1��6j   $��5,10,5,5q�52   )    �� 	MaxLength$ 20��6;      ValueDataType" ��6J   
�������6�   53      54      �� 56   
   -   5        	 ��Name$	 contentTextBox��57      $��1��6%   
�������$��5q�6J   $��5q�6U   
 �� TextWrapping$

 Wrap=�58      $��Stretch=�59      $	��280��5:       �� AcceptsReturn . " �� VerticalScrollBarVisibility$
 Auto=�5<       �� 	IsEnabled .   
createText)  #MaterialDesignThemes.Wpf.HintAssist   Hint# �  5>      $	 400��5?      .��5@      5A      �� 5H   
   $��0��6   $��1��6"   .+�5I      �  5J      �� 5K      $	��100 �6'   �� 5L      .+�5N      �� $��0��6     
createDate#���  6(   $��15(�6O   $��
0,10,400,5q�6]   $��Center=�6q   $
��Left=�6�   $��2��6�   &   Xceed.Wpf.Toolkit.DateTimePicker  5O      -   5        $��dateTime��5O   &   $��1��66   $��15(�6F   
�������   CalendarWidth$	 280Q�6l   $��	10,10,5,5q�6�   6�   5P      5Q      �� 5S   
   $��1��6   $��1��6%   $	��250��62   $	��300��6>   .+�5T      � $	��250��6   $	��300��6    5U      �� 5V      $	��255 �6$   �� 5W      .+�5Y      #  MaterialDesignThemes.Wpf.Card  -   5        $��myCard��5Y   &   $	��245��64   $	��255��6@   $��0q�6M   $��0��6X   .��5Z      �  5[      �� 5\      $��0 �6,   �� 5]      $��* �6,   �� 5^      $��35 �6,   .+�5b      �� $��1��6%   $��8,10,8,0q�62   .+�5c      �� -   5        $��
cardHeader��5c   (   
���   �$
��Bold"�6M    �� TextAlignment$ Center=�6_   $��14(�6v   #���   6�   $��	Underline{�6�   �� 5d      $	��180��6+   $��Disabled=�6;   $��Hidden=�6q   ��. $��3,10,5,3q�6�   .��5e   "   �� -   5        $��cardContent��5e   -   
���   �$
��Wrap=�6S   $��Center=�6h   #���  6�   5f      5j      �� 5l      $��Center=�6%   $��2��6B   $ Vertical=�6O   $��Center=�6f   $	��225��6�   $��35��6�   $
��10,0q�6�   .+�5m      �� 
���   �$��0 1 1 1q�69   6U   �� 5n      -   5        $��cardDateTime��5n   (   $
��Left=�6<   $��Center=�6W   
���   �$��2,6,8,8q�6�   #���  6�   5o      5q      5r      �� 5s      -   5        $��cardAddButton��5s      $��1��6.   $��3q�6;   .��6\   Добавить запись6m   5t      5u      �� 5v   
   -	   5        $��counter��5v      $��1��6#   $��10,467,395,10q�63   $��1��6J   $��Center=�6W   $
��Left=�6r   0/4006�   5x      5y      