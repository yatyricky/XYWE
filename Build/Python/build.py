# -*- coding: utf-8 -*-

import sys
import datetime
import util.filesystem as fs
import util.path
import os

path = util.path.path

class RedirectLog:
    def __init__(self, log, stdout):
        self.__stdout  = stdout
        self.__logfile = file(log, 'w')

    def __del__(self):
        self.__logfile.close()

    def write(self, s):
        try:
            self.__logfile.write(s)
            self.__stdout.write(s)
        except:
            pass

def Log():
    logname = 'build.log'
    if len(sys.argv) >= 2 and sys.argv[2] != 'update':
        logname = sys.argv[2]
    elif len(sys.argv) >= 3:
        logname = sys.argv[3]
    sys.stdout = RedirectLog(logname, sys.stdout)

def update_move_ydwe(configuration):
    from copy_all           import copy_component

    print ('update_move_ydwe')
    fs.copy_directory(
          path['Development'] / 'Editor' / 'Component'
        , path['ProjectRoot'] / 'Build' / 'publish' / configuration / 'core' / 'ydwe'
        , []
        , False)

def update_move_xywe(configuration):
    print ('update_move_xywe')
    fs.copy_directory(
          path['Development'] / 'Editor' / 'ComponentXYWE'
        , path['ProjectRoot'] / 'Build' / 'publish' / configuration
        , []
        , False)

def update_pack(configuration):
    print ('update_pack')
    print (path['ThirdParty'] / 'LazyTools' / 'LazyPacker.exe')
    packer = path['ThirdParty'] / 'LazyTools' / 'LazyPacker.exe'
    config = path['ProjectRoot'] / 'Build' / 'publish' / configuration / 'lazypack'
    edition = 'Normal'
    language = 'zhCN'
    mode = 'Silent'
    os.system(str(packer) + ' ' + str(config) + ' ' + edition + ' ' + language + ' ' + mode)

def update(configuration, ignoreYDWE = False):
    Log()
    if ignoreYDWE:
        print ('build - update')
    else:
        print ('update')
    t = datetime.datetime.now()
    print ('update {0}'.format(t))

    if not ignoreYDWE:
        update_move_ydwe(configuration)
    update_move_xywe(configuration)
    update_pack(configuration)

def move_include():
    inc = path['ProjectRoot'] / 'Build' / 'include'
    if fs.exists(inc):
        fs.copy_directory(
              inc
            , path['ResultRoot'] / 'include'
            , ['.h']
            , True)

def build_clear(configuration):
    print ('build_clear')
    fs.remove_all(path['ResultRoot'] / 'bin' / configuration)
    fs.remove_all(path['ResultRoot'] / 'obj' / configuration)
    fs.remove_all(path['ResultRoot'] / 'lib' / configuration)
    fs.remove_all(path['ProjectRoot'] / 'Build' / 'publish' / configuration)

def build_move(configuration):
    print ('build_move')
    fs.copy_directory(
          path['ResultRoot'] / 'bin' / configuration
        , path['ProjectRoot'] / 'Build' / 'publish' / configuration / 'core' / 'ydwe'
        , ['.pdb', '.exp', '.ilk', '.aps', '.lib']
        , False)

def build_all(msvc_version, configuration):
    from complie            import complie
    from build_anti_bj_leak import build_anti_bj_leak
    from copy_all           import copy_all
    from pack_skin          import pack_skin
    from pack_units         import pack_units

    complie(msvc_version, configuration)
    build_anti_bj_leak()
    copy_all(msvc_version, configuration)
    pack_skin()
    pack_units()

def build(msvc_version, configuration):
    Log()
    print ('build')
    t = datetime.datetime.now()
    print ('build {0}'.format(t))
    build_clear(configuration)
    move_include()
    build_all(msvc_version, configuration)
    build_move(configuration)
    update(configuration, True)
    print ('time {0}'.format(datetime.datetime.now() - t))

def Configuration():
    if len(sys.argv) > 1:
        return sys.argv[1]
    return 'Debug'

def IsUpdateMode():
    return len(sys.argv) >= 2 and sys.argv[2] == 'update'

if __name__ == '__main__':
    util.path.ResetPath(Configuration())
    if (IsUpdateMode()):
        update(Configuration())
    else:
        build(120, Configuration())
