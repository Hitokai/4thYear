   M S B A M L   `   `   `  ����@  <sqlDB, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:sqlDB.EditControlssqlDB.EditControls  5          sqlDB.EditControls.create   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      2local clr-namespace:sqlDB.EditControls     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      
�������.��5
      � -   5        $��pageContent��5
        � RowDefinitions  5   
   �� 5      $	��90* �6   �� 5      $	��90* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��60* �6   �� 5      $	��90* �6   .+�5   
   �� $��0��6   
����·�$��0,0,0,10q�6<   .+�5      � $��86��6    � ColumnDefinitions 5      �� 5      $
��230* �6'   �� 5      $
��500* �6'   �� 5      $
��230* �6'   .+�5      �� -   5        $��backBut��5      $��
Назад��6(   $��	20,0,20,0q�68   6c   �� 5      $+��%Добавление водителя��6   $��1��66   $��Center=�6F   $��Center=�6j   $��25(�6�   ���	#DDFFFFFF6�   �� 5      -   5        $��addDriverBut��5      $��Добавить��6-   $��2��6A   $��	20,0,20,0q�6Q   6f   5       5!      �� 5"   
   -   5        $��addFname��5"      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Имя��6"   $��25(�6G   $��2��6U   $��200,10,200,10q�6b    �� 	MaxLength$ 60��6y   6�   �� 5#   
   -   5        $��addLname��5#      $ Фамилия��6"   $��25(�6K   $��3��6Y   $��200,10,200,10q�6f   $ 60��6}   6�   �� 5$   
   -   5        $��addMname��5$      $ Отчество��6"   $��25(�6L   $��4��6Z   $��200,10,200,10q�6g   $ 60��6~   6�   �� 5%   
   -   5        $��addDate��5%      $��5��6!   $ Возраст��6.   $��25(�6W   $��200,10,200,10q�6e   $ 2��6|   6�   �� 5&   
   -   5        $��addPassData��5&      $/ )Серия и номер паспорта��6%   $��25(�6]   $��6��6k   $��200,10,200,10q�6x   $ 10��6�   6�   �� 5'   
   -	   5        $��addPravaBlyat��5'      $! Категория прав��6(   $��25(�6X   $��7��6f   $��200,10,200,10q�6s   5)      5+      5,      