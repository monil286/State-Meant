   M S B A M L   `   `   `  ����	  Login$    Login.UserControl_GameQuestion   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        � 	Resources  5         masterImage �� 	UriSource��%7   &	        �� 5	   
   $ blank_state_map.jpg?�6*   5
      .��5      � -   5         �Name$ 
mapContent��5       � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5       .+�5"   
   �� -   5         ��Name$ 
label_year��5"      $y�Hidden=�6$   $��1��68   $��1��6E   $��1��5#      $��2��6$   $��80(�65   $
��Bold"�6C   
�������6U   �� 5$   
   -   5         ��Name$ text_block_question��5$      $y�Hidden=�61   $��1��6E   $��2��6R   $��3��5%      $��2��6%   $��45(�66   $��Medium"�6D   
�������$
��Wrap=�5&   '   �� 5'   
   -   5         ��Name$ image_map_section��5'      $y�Hidden=�6+   $��3��6?   $��2��6L   $��6��5(      $��3��6!   $
��Fill=�65   �� 5)   
   -   5         ��Name$ stack_panel_solution_set��5*      $��3��5)      $��1��6"   $��1��62   $��6��6F   .+�5+      �� -   5        $ text_block_option_1��5+      
�������$
��Wrap=�6H   $��30(�6\   	 � Cursor$
	 Hand��5-   T   �� 5.      -   5        $ text_block_option_2��5.      
�������$
��Wrap=�6H   $��30(�6\   $
	 Hand��50   T   �� 51      -   5        $ text_block_option_3��51      
�������$
��Wrap=�6H   $��30(�6\   $
	 Hand��53   T   �� 54      -	   5        $ text_block_option_4��54      
�������$
��Wrap=�6H   $��30(�6\   $
	 Hand��56   T   57      � 58   
   -
   5        
 �Name$
 progress_bar��58      $��10��6,   $��1��6:   $��1��6J   $��4��6[   59      5:      