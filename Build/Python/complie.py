# -*- coding: utf-8 -*-

import os
import subprocess
import util.msvc
import util.path
import util.filesystem as fs
path = util.path.path

def run_bat(bat_path, cmd=None):
    if cmd is None:
        cmd = str(bat_path)
    else:
        cmd = '"' + str(bat_path) + '" ' + cmd

    p = subprocess.Popen(cmd, cwd=str(bat_path.parent_path()), stdin=open(os.devnull), stderr=subprocess.PIPE, stdout=subprocess.PIPE, shell=True)
    for line in p.stdout.readlines():
        print(line)

def copy_crt_dll(msvc_version, configuration):
    if configuration == 'Release':
        crt_dll_dir = fs.path(util.msvc.vc_install_dir) / 'redist' / 'x86' / ('Microsoft.VC' + str(msvc_version) + '.CRT')
    else:
        return
    if fs.exists(crt_dll_dir):
        fs.copy_directory(crt_dll_dir, path['ResultCore'], ['.dll'])

def is_dev():
    import sys
    if len(sys.argv) > 3:
        return 'Dev' == sys.argv[3]
    return False

def complie(msvc_version, configuration):
    print('complie')
    print('msvc.setup_env')
    util.msvc.setup_env(msvc_version)
    print('rebuild opensource')
    util.msvc.rebuild(path['ThirdParty']/ 'Microsoft' / 'Detours' / 'Current' / 'sln' / 'Detours.sln', configuration)
    util.msvc.rebuild(path['OpenSource']/ 'StormLib' / 'Current' / 'StormLib.sln', configuration)
    util.msvc.rebuild(path['OpenSource']/ 'all.sln', 'Release')
    util.msvc.rebuild(path['OpenSource']/ 'Lua' / 'Current' / 'makefiles' / 'luacore.sln', configuration)
    util.msvc.rebuild(path['OpenSource']/ 'luaffi' / 'makefiles' / 'luaffi.sln', configuration)
    print('rebuild ydwe')
    if not is_dev():
        util.msvc.rebuild(path['Development']/ 'Editor' / 'Core' / 'Solution' / 'YDWE.sln', configuration)
    util.msvc.rebuild(path['Development']/ 'Editor' / 'Plugin' / 'YDColorizer' / 'YDColorizer.sln', configuration, 'Any CPU')
    print('copy crt dll')
    copy_crt_dll(msvc_version, configuration)

def Configuration():
    import sys
    if len(sys.argv) > 1:
        return sys.argv[1]
    return 'Debug'

if __name__ == '__main__':
    util.path.ResetPath(Configuration())
    complie(120, Configuration())
