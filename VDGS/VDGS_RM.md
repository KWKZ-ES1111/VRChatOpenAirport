# VDGS 配置方法

## 1.配置VDGS位置

  VDGS位置应当位于停机位的中线延长线上，距离驾驶员视角10-20m位置
  
## 2.配置VDGS检测

  VDGS通过检测VDGS_Core下的碰撞体内是否有目标刚体来判断状态和位置映射，因此，这个碰撞体的覆盖范围应该是机位从左到右，从VDGS下方到机位进位滑行道上。
  
  VDGS基于`CnterLineAnchor`，`StopAnchor`和鼻轮上刚体的位置进行左右和前后引导。`CnterLineAnchor`放置在停机位中线上任意位置，**z朝向VDGS/航站楼** 。`StopAnchor`放置在停止线上， **z同样朝向航站楼**。
  
## 3.配置航空器鼻轮

  VDGS预制件中自带有可用于检测的`V20NFW`触发器,可将该物体放置并绑定在航空器前鼻轮轮轴位置。
  
  在VDGS_Core中将绑定好的触发器指定到`TargetAircraft`一栏中。
  
  VDGS会检测进入机位是否为对应机位的对应机型。
  
  如果
  
  ```
  
  机型正确且机位正确：显示对应机型四字码并进入引导流程
    
  机型正确机位不正确：显示对应机型私自吗，显示Stop并拒绝引导

  机型机位均不正确：显示INOP并显示Stop拒绝引导
  
  ```  
  VDGS通过比对进入检测区域内的触发器是否包含`AircrafeTypeLabel`中元素的名称来决定显示内容并是否引导。
  
## 4.VDGS开关

  VDGS在立柱底部有可交互开关，可由触碰触发也可由交互触发。开关控制`Displays`和`Arrows`的`isActive`。可以在VDGS_Switch中的`TargetObjects`加入其它元素。
  
