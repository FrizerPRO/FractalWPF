   M S B A M L   `   `   `  ����F  BColorPicker, Version=3.1.1.0, Culture=neutral, PublicKeyToken=null>.clr-namespace:ColorPicker;assembly=ColorPickerColorPicker  5   	   E AFractalWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:FractalWPF
FractalWPF 5	   	      FractalWPF.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   Fcolorpicker.clr-namespace:ColorPicker;assembly=ColorPicker     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :xctk)http://schemas.xceed.com/wpf/xaml/toolkit     5   	   *localclr-namespace:FractalWPF     5	   	   -   5          � 
ResizeMode$  	CanResize=�5   	    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)   $	��800��65   $	��449��6D   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��8* �6   6*    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��8* �6   6,   .+�5   
   � $��0��6   $��1��6    5      �� 5      $
��1.5* �6#   62   �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   �� 5      6%   .+�5       �  5!      �� 5"      6&   �� 5#      6&   .+�5&      �� -   5         ��Name$ 	textBlock��5&      $
��Bold"�6/    �� TextAlignment$ Center=�6A   $��17(�6X   
����ح�Глубина:6�   �� 5'      -   5         ��Name$ 	LevelText��5'      $��Right=�6�    �� TextAlignment$ Center=�6�   $��
57,64,83,0q�6�   $��16(�6�   $
��Bold"�6�   ${�False��6�   $��22��6�   $	��Top=�6  ��6-   ��  �� ElementName$ LevelSlider��	 �� Path$	 Value�
 �� UpdateSourceTrigger$
 PropertyChanged=�6  �� 5(      -   5        $��slider��5(       �� IsSnapToTickEnabled$
 True��6*    �� TickFrequency$ 1Q�6E    �� TickPlacement$ TopLeft=�6X    � Minimum$ 1Q�6p    � Maximum$ 17Q�6|   $��1��6�   6�   5)      �� 5*      $��1��6   
����ح�$��16(�6?   $
��Bold"�6M   $ Center=�6_   Выберите�� 6�   6�   Фрактал:6�   �� 5,      -   5        $��frac1Button��5,      $��2��6(   .��5-      �� $��19(�6   $
��Bold"�6*   Дерево6D   5.      �� 5/      -   5        $��frac2Button��5/      $��3��6(   .��50      �� $��17(�6   $
��Bold"�6*   $ Center=�6<   Кривая�� 6Z   6f   
Коха6v   51      �� 52      -   5        $��frac3Button��52      $��4��6(   .��53      �� $��14(�6   $
��Bold"�6*   $ Center=�6<   
Ковер�� 6Y   6e   Серпинского6|   54      �� 55      -   5        $��frac4Button��55      $��5��6(   .��56      �� $��14(�6   $
��Bold"�6*   $ Center=�6<   Треугольник�� 6_   6k   Серпинского6�   57      �� 58      -	   5        $��frac5Button��58      $��6��6(   .��59      �� $��14(�6   $
��Bold"�6*   $ Center=�6<   Множество�� 6]   6i   Кантора6|   5:      5;      � 5<   
   $��1��6   $��0��6    5=      �� 5>      $
��1.5* �6    60   �� 5?      $
��1.2* �6    60   �� 5@      $
��1.5* �6    60   �� 5A      $��* �6    6-   �� 5B      $
��1.5* �6    60   �� 5C      $��* �6    6-   �� 5D      $
��1.5* �6    60   �� 5E      $��* �6    6-   �� 5F      $
��1.5* �6    60   �� 5G      $��* �6    6-   �� 5H      $
��1.5* �6    60   �� 5I      $��* �6    6-   �� 5J      $
��1.5* �6    60   �� 5K      $��* �6    6-   �� 5L      $��* �6    6-   �� 5M      $��* �6    6-   �� 5N      $��5* �6    6.   .+�5R      �� -
   5        $��14��5R      $
��Bold"�6#   .��6H   
ScreenShot6T   �� 5S      -   5        $��rightAngleText��5S      $��10��6*   $
��Bold"�68   
����ح�.��6a   Правй Угол:6n   �� 5T      -   5        $��leftAngleText��5T      $��12��6)   $
��Bold"�67   
����ح�.��6`   Левый Угол:6m   �� 5U      -   5        $��nextTimeText��5U      $��6��6(   $
��Bold"�65   
����ح�.��6^   Увеличение:6k   �� 5V      -   5        $��widthBetweenText��5V      $��8��6,   $
��Bold"�69   
����ح�.��6b   Расстояние:6o   �� 5W      -   5        $��colorBeginLabel��5W      $��2��6+   $
��Bold"�68   
����ح�.��6a   " Начало градиента:6t   �� 5X      -   5        $��colorEndLabel��5X      $��4��6)   $
��Bold"�66   
����ح�.��6_    Конец градиента:6q   %   ColorPicker.PortableColorPicker  5Y      -   5          Name$ 
colorBegin��5Y   ;   $��3��6.   6O     5Z      -   5        $ colorEnd��5Z   ;   $��5��6.   6M   �� 5[      -   5        $��rightAngleSlider��5[      $
 True��60   $ 1Q�6K   $ TopLeft=�6^   $ 0Q�6v   $ 90Q�6�   $��11��6�    � SmallChange$ 1Q�6�   �� 5\      -   5        $��leftAngleSlider��5\      $
 True��6/   $ 1Q�6J   $ TopLeft=�6]   $ 0Q�6u   $ 90Q�6�   $��13��6�   $ 1Q�6�   �� 5]      -   5        $��nextTimesSlider��5]      $ TopLeft=�6/   $
 1.25Q�6G   $ 3Q�6V   $��7��6d   $ 1Q�6�   �� 5^      -   5        $��widthBetweenSlider��5^      $
 True��61   $ TopLeft=�6L   $ 9Q�6d   $ 1Q�6q   $ 35Q�6�   $��9��6�   $ 1Q�6�   6�   � 5_      $��1��6    5`      �� 5a      6)   �� 5b      6)   �� 5c      6)   .+�5e      �� -   5         ��Name$ minSizeButton��5e      $
��Bold"�60   .��6]   min6b   �� 5f      -   5        $ medSizeButton��5f   )   $��1��6   $
��Bold"�6@   .��6m   med6r   �� 5g      -   5        $ maxSizeButton��5g   )   $��2��6   $
��Bold"�6@   .��6m   max6r   5h      �� 5i      
����ح�$
��Bold"�6+   .��6=   Размер окна6J   � 5j      $��15��6    5l      �� 5m      6)   �� 5n      6)   �� 5o      6)   �� 5p      6)   .+�5r      �� -   5        $
��Bold"�5r      $��0��6B   .��6R   x16V   �� 5s      -   5        $
��Bold"�5s      $��1��6+   .��6Q   x26U   �� 5t      -   5        $
��Bold"�5t      $��2��6+   .��6Q   x36U   �� 5u      -   5        $
��Bold"�5u      $��3��6+   .��6Q   x56U   5v      5w      �� 5x   
   -   5        
��� �|�$
��Bold"�5x   (   $��16(�6:   .��6`   Построить6k   �� 5y   
   -   5         ��Name$ 
canvasGrid��5y      $��1��6+   $��1��6;   $��Visible=�6I   $��Visible=�6q   .��5z      �� -    5         ��Name$ drawingSurface��5z      $
}�True��6-   $��Center=�6A   $��Center=�6^   $	��300��6y   $	��700��6�   5{      5      5�      