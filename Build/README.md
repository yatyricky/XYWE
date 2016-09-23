# 项目打包

## 流程说明

### 第一次打包

使用VS2015打开Development/Launcher/XYWE.sln并用Release模式生成解决方案  
会生成XYWE的基础工具包，生成的工具会被放到/Development/Editor/ComponentXYWE内

运行: Build_Release.bat  
生成内核，并将XYWE所有资源文件发布到/Build/publish/Release并用LazyPacker二次打包

最终生成的可执行的WE目录为/Build/publish/Release/LazyRelease

### 重构内核并打包 ###

运行: Build_Release.bat  
重新生成内核，并将XYWE所有资源文件发布到/Build/publish/Release并用LazyPacker二次打包

### 重构XYWE基础工具并打包 ###

使用VS2015打开Development/Launcher/XYWE.sln并用Release模式生成解决方案  
重构XYWE的基础工具包

Update_Release.bat  
将YDWE组件目录(/Development/Editor/Component)发布到/Build/publish/Release/core/ydwe  
将XYWE组件目录(/Development/Editor/ComponentXYWE)发布到/Build/publish/Release/  
完成以上步骤后再自动使用LazyPacker二次打包

## 文件说明

### Build_Release.bat ###

* 生成YDWE到输出目录的ydwe子目录(/Build/publish/Release/core/ydwe)
* 复制XYWE的外置工具及启动器到输出目录(/Build/publish/Release)
* 打包XYWE并输出内容到LazyRelease文件夹

生成的最终可用于运行&测试&发布的完整的XYWE的根目录为/Build/publish/Release/LazyRelease

### Update_Release ###

* 复制YDWE组件目录(/Development/Editor/Component)到输出目录中的ydwe子目录(/Build/publish/Release/core/ydwe)
* 复制XYWE组件目录(/Development/Editor/ComponentXYWE)到输出目录(/Build/publish/Release)
* 用LazyPacker对输出目录执行二次编译，打包的最终输出目录为/Build/publish/Release/LazyRelease
