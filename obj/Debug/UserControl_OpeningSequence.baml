   M S B A M L   `   `   `  ����	  Login'    !Login.UserControl_OpeningSequence   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      � -   5          �Name$  opening_sequence_grid��5      
���   �.+�5	   
   r� -   5         r�Name$ opening_clip��5	       r� LoadedBehavior$
 Play=�6-    r� UnloadedBehavior$
 Stop=�6C    r� Volume$	 0.0Q�6[    r� Source$C =C:\Users\tmacedo\Desktop\462_media_files\opening_sequence.wmv?�5
      5      r� 5   
   -   5        $ background_sound��5      $	 1.0Q�61    � Triggers 5      :� 5       :� RoutedEvent$ MediaElement.Loaded��6   [�5      �� 5      .��5      �� .��5   "   p�  p� Source$` ZC:\Users\tmacedo\Documents\StateMeant\StateMeant\Yankee doodle - original song_clipped.wav?�60   	 �� 
TargetName$	 background_sound��5   0   
 g� RepeatBehavior$
 Forever��5   0   5      5      5      5      �� 5   
   -   5         ��Name$ title_label��5      $y�Hidden=�6%   $��75(�69   $
��Bold"�6G   $��Center=�5      $��Center=�6-   
�������6H   5      5       