   M S B A M L   `   `   `  ����C  ?Tabitems, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:TabitemsTabitems  5   	       Tabitems.CreateOrder   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Tabitems     5   	     � Title$  CreateOrder��5   	   $	��330��6   $	��430��6*    � 
ResizeMode$ NoResize=�66    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�  '��       '�� s     '�� �     '�� �    '��     �� 5
   
   " ��6   .�5      ��  � ��$ 	10,10,0,0q�6'   �� 5       � ��$ 28��6'   5      �� 5   
   " ��6   .�5      ��  �@��Padding$ 0,2,0,0q�6(   5      �� 5   
   " ��6   .�5      ��  � �� �#F4F9FD6+   �� 5       � �� �#D0DDF36,   �� 5       � ��$ 28��6'   �� 5       � ��$ 60��6&   �� 5       � ��$ 3q�6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 	0,10,10,0q�6'   �� 5       � ��$ 28��6'   5      �� 5   
   " ��6   .�5      ��  � ��$ 2q�6'   �� 5       � ��$ 28��6'   �� 5       � ��$ 	0,10,10,0q�6'   5       5!      .��5"      �  � RowDefinitions 5#   
   �� 5$      �� 5%      �� 5&      �� 5'      �� 5(      �� 5)       � ColumnDefinitions 5+   
   �� 5,      $	��130 �6   �� 5-      .+�50   
   �� $��клиент��6   �� 51   
   $��автомобиль��6   $��1��6%   �� 52   
   $��код цвета��6   $��2��6$   �� 53   
   $#��цветовая группа��6   $��3��6*   �� 54   
   $��тара��6   $��4��6   �� 57   
   $��1��6/   ��6   ��  �� Path$ Client�6/   �� 58   
   $��1��6-   $��1��6=   ��6   �� $
 Auto�6=   �� 59   
   $��1��62   $��2��6B   ��6   �� $ 	ColorCode�6B   �� 5:   
   -   5        $��1��5:      $��3��6#   .@�5;      �� $��white��6   �� 5<      $
��grey��6   �� 5=      $��black��6   �� 5>      $
��blue��6   �� 5?      $��green��6   �� 5@      $��yellow��6   �� 5A      $��orange��6   �� 5B      $	��red��6   �� 5C      $��purple��6   �� 5D      $��beige��6   �� 5E      $��brown��6   5F      �� 5G   
   $��1��6   $��4��6&   	 �� Orientation$	 
Horizontal=�63   .+�5H      �� -   5        $��60��5H   1   ��6   �� $
 Tare�6<   �� 5I   
   $-��'3х стадийное покрытие��6   �� 5J      -   5        
 d� 	IsChecked$
 FalseY�5J      $��	10,22,0,0q�6D   5K      �� 5L   
   $��Right=�6   $	 
Horizontal=�61   $��5��6J   $��1��6W   $��0,0,10,0q�6g   .+�5M      �� -   5         �� 	IsDefault . .��5M   ;   OK6?   �� 5N       �� IsCancel . .��6%   Отмена6-   5O      5P      5Q      