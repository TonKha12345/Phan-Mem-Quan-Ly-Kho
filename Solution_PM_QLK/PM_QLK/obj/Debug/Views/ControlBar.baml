   M S B A M L   `   `   `  ����A  =PM_QLK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:PM_QLK.ViewsPM_QLK.Views  5      +clr-namespace:PM_QLK.ViewsPM_QLK.Views  5	          PM_QLK.Views.ControlBar   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:PM_QLK.Views     5      1
controlbarclr-namespace:PM_QLK.Views     5	      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5
      _ [MaterialDesignThemes.Wpf, Version=4.9.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5        $��
controlBar��5         controlbarVM  � DataContext#  �   5      .  (System.Windows.Interactivity.Interaction   Triggers 5      /  )System.Windows.Interactivity.EventTrigger  5   
      	EventName$ 	MouseDown��6   .  (System.Windows.Interactivity.TriggerBase   Actions. 5      6  0System.Windows.Interactivity.InvokeCommandAction     Command 6$   �� *MouseDownCommand+   CommandParameter 5   $   ��  �� ElementName$ 
controlBar��5      .��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone     Mode$ PrimaryLight=�6#   .��5      ]� ��.  .+�5      �� $��Right=�6    �� Orientation$ 
Horizontal=�5      .+�5      �� 	 � ToolTip$	 Minimize��6   
 c� OverflowMode$
 AsNeeded=�5      $��1q�5       
����p����5"      �� *MinimizeWindowCommand+��5#      �� $ 
controlBar��.��5$      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ WindowMinimize=�62   5%      �� 5'      $
 AsNeeded=�6   $	 Maximize��5(      $��1q�5)      
���p���5+      �� *MaximizeWindowCommand+��5,      �� $ 
controlBar��.��5-        $ WindowMaximize=�62   5.      �� 50      $
 AsNeeded=�6   $	 Đóng��51      $��1q�52      
����p����54      �� *CloseWindowCommand+��55      �� $ 
controlBar��.��56        $ CloseOutline=�62   57      58      d� 5:      $
��Left=�6    ' #MaterialDesignHamburgerToggleButton#��[ 5;      5=      �� 5?      $
��Left=�6   $��16,0,0,0q�5@      $��Center=�5A      ��5B      �� *Tag+$ 
controlBar��5D      5E      5I      5J      