   M S B A M L   `   `   `  ����B  >planner, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:plannerplanner  5   	       planner.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:planner     5   	   V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5        $	��600��5      $
��1080��6'   
�������  � 
ResizeMode$  NoResize=�6G    � WindowStartupLocation$ CenterScreen=�6]    � WindowStyle$
 None=�6�    � 	Resources 5	         OpenMenu �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	CloseMenu��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 70Q�63     5      $ 0:0:0.5��6'   $	 200Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 200Q�63     5      $ 0:0:0.5��6'   $ 70Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5      �� #��[ 6   5      .��5!      � ���	#FFDEDEDE.+�5#   
   � -   5         �Name$ GridMain��5#      $��Right=�6!   $��Bottom=�6=   $	��540��6X   $
��1010��6e   .+�5$      #  MaterialDesignThemes.Wpf.Card  $��32q�6"   $��16q�6/   .��5%      �� 
���   �$
��Wrap=�6/      MaterialDesignTitleTextBlock#���  6C   ��My First Material Design AppsfdfsfMy First Material Design AppsfdfsfMy First Material Design AppsfdfsfMy First Material Design AppsfdfsfMy First Material Design AppsfdfsfMy First Material Design AppsfdfsfMy First Material Design Appsfdfsf6j  5&      5'      � 5(   
   $��60��6   $	��Top=�6   ���	#FF5C99D6 J� Effect 5)      3  -System.Windows.Media.Effects.DropShadowEffect  5*         
BlurRadius$ 1Q�6#      ShadowDepth$ 1Q�62      Color$ 	#FFACACAC��6B   .+�5-      ��  �� Orientation$ 
Horizontal=�6   $��Right=�62   $��0,0,14,0q�6N   .+�58      �� -   5         ��Name$ minimizeWindow��58       . *MaterialDesignFloatingActionMiniDarkButton#��[ 61   ���	#FF5C99D6���	#FF5C99D6$��10,10q�5:   F   .��5;      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ WindowMinimize=�6.   $��24��6D   $��24��6P   5<      �� 5=      -   5        $ closeButton��5=      #��[ 6.   ���	#FF5C99D6���	#FF5C99D6.��5@        $ Close=�6.   $��24��6;   $��24��6G   5A      5C      �� 5D      $��Center=�6    
 header#���  65   $��Center=�6U   $��22(�6p   5F      � 5G   
   -   5        $ GridMenu��5G      $��70��6!   $
��Left=�6,   ���	#FF31577E 5H        5I      $ 2Q�6#   $ 1Q�62   $ 	#FFAEAEAE��6B   .+�5K      �� .+�5L      � $	��150��6   
������� J� RenderTransformOrigin$ 0.5,0.5&�67   z�5M      V� 5N      .~�5O      �� �� 5P      �� 5Q      T� 5R      5S      .+�5U      �� -   5        $ ButtonOpenMenu��5U      $��60��65   $��60��6A   $��5q�6L   $��Right=�6W   $	��Top=�6s    0 ,MaterialDesignFloatingActionMiniAccentButton#��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5V        $
 Menu=�62   $��25��6>   $��25��6I   5W      �� 5X      -   5        $ ButtonCloseMenu��5X      $y�	Collapsed=�66   $��60��6M   $��60��6Y   $��5q�6d   $��Right=�6o   $	��Top=�6�   #��[ 6�   ���	#FF31577E��6�   Z� ��6�   Z� .��5Y        $ 	ArrowLeft=�62   $��25��6C   $��25��6N   5Z      �� 5\      $��80��6   $��Bottom=�6(   5]      �� 5^      -   5         ��Name$ ListViewMenu��5^      ���	#FF5C99D6$��Disabled=�6H   .@�5_      �� -	   5         ��Name$ ItemHome��5_   #   $��60��65   .��5`      �� $ 
Horizontal=�6%   .+�5a        $ ViewDashboard=�66   $��25��6K   $��25��6W   $��10q�6b   �� 5b        menuHome#���  6(   $��Center=�6J   $��20 10q�6e   5c      5d      �� 5e      -
   5        $ 
ItemCreate��5e   #   $��60��67   .��5f      �� $ 
Horizontal=�6%   .+�5g        $ Pencil=�66   $��25��6D   $��25��6P   $��10q�6[   �� 5h        
menuCreate#���  6(   $��Center=�6L   $��20 10q�6g   5i      5j      �� 5k      -   5        $ ItemSettings��5k   /   $��60��6#   .��5l      �� $ 
Horizontal=�6%   .+�5m        $ Settings=�66   $��25��6F   $��25��6R   $��10q�6]   �� 5n        menuSettings#���  6(   $��Center=�6N   $��20 10q�6j   5o      5p      5w      5x      5y      5z      5{      