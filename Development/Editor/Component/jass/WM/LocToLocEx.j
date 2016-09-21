#ifndef LocToLocExIncluded
#define LocToLocExIncluded

library LocToLocEx//��->α��
    struct LocEx
        real x
        real y
        static method create takes real x,real y returns thistype
            local thistype l=thistype.allocate()
            set l.x=x
            set l.y=y
            return l
        endmethod
    endstruct
//���ص�
    function GetUnitLocEx takes unit u returns LocEx//��λλ��
        return LocEx.create(GetUnitX(u),GetUnitY(u))
    endfunction
    function GetDestructableLocEx takes destructable whichDestructable returns LocEx//���ƻ���λ��
        return LocEx.create(GetDestructableX(whichDestructable), GetDestructableY(whichDestructable))
    endfunction
    function GetOrderPointLocEx takes nothing returns LocEx//�����
        return LocEx.create(GetOrderPointX(),GetOrderPointY())
    endfunction
    function GetPlayerStartLocationLocEx takes player whichPlayer returns LocEx//��ʼ��
        return LocEx.create(GetStartLocationX(GetPlayerStartLocation(whichPlayer)),GetStartLocationY(GetPlayerStartLocation(whichPlayer)))
    endfunction
    function GetItemLocEx takes item whichItem returns LocEx//��Ʒλ��
        return LocEx.create(GetItemX(whichItem), GetItemY(whichItem))
    endfunction
    function WaygateGetDestinationLocBJEx takes unit waygate returns LocEx//������Ŀ�ĵ�
        return LocEx.create(WaygateGetDestinationX(waygate), WaygateGetDestinationY(waygate))
    endfunction
    function GetUnitRallyPointEx takes unit u returns LocEx//��λ�����
        local location l=GetUnitRallyPoint(u)
        local real x=GetLocationX(l)
        local real y=GetLocationY(l)
        call RemoveLocation(l)
        set l=null
        return LocEx.create(x,y)
    endfunction
    function GetRectCenterEx takes rect r returns LocEx//��������
        return LocEx.create(GetRectCenterX(r), GetRectCenterY(r))
    endfunction
    function GetRandomLocInRectEx takes rect r returns LocEx//���������
        return LocEx.create(GetRandomReal(GetRectMinX(r), GetRectMaxX(r)), GetRandomReal(GetRectMinY(r), GetRectMaxY(r)))
    endfunction
    function PolarProjectionBJEx takes LocEx l, real dist, real angle returns LocEx//������λ�Ƶ�
        local real x =l.x+ dist * Cos(angle * bj_DEGTORAD)
        local real y =l.y+ dist * Sin(angle * bj_DEGTORAD)
        call l.destroy()
        return LocEx.create(x,y)
    endfunction
    function CameraSetupGetDestPositionLocEx takes camerasetup whichSetup returns LocEx//��ͷĿ���
        return LocEx.create(CameraSetupGetDestPositionX(whichSetup),CameraSetupGetDestPositionY(whichSetup))
    endfunction
    #if WARCRAFT_VERSION>=124
        function GetSpellTargetLocEx takes nothing returns LocEx//�����ͷŵ�
            return LocEx.create(GetSpellTargetX(),GetSpellTargetY())
        endfunction
    #else
        function GetSpellTargetLocEx takes nothing returns LocEx//�����ͷŵ�
            local location l=GetSpellTargetLoc()
            local real x=GetLocationX(l)
            local real y=GetLocationY(l)
            call RemoveLocation(l)
            set l=null
            return LocEx.create(x,y)
        endfunction
    #endif
//����Ϊ��
    function SetUnitPositionLocEx takes unit u,LocEx l returns nothing//���õ�λλ��
        call SetUnitPosition(u,l.x,l.y)
        call l.destroy()
    endfunction
    function SetUnitXYEx takes unit u,LocEx l returns nothing//���õ�λλ��
        call SetUnitX(u,l.x)
        call SetUnitY(u,l.y)
        call l.destroy()
    endfunction
    function CreateNUnitsAtLocEx takes integer count, integer unitid, player whichPlayer, LocEx loc, real face returns group//������λ
        call GroupClear(bj_lastCreatedGroup)
        loop
            set count=count-1
            exitwhen count<0
            if (unitid == 'ugol') then
                set bj_lastCreatedUnit = CreateBlightedGoldmine(whichPlayer,loc.x,loc.y,face)
            else
                set bj_lastCreatedUnit = CreateUnit(whichPlayer,unitid,loc.x,loc.y,face)
            endif
            call GroupAddUnit(bj_lastCreatedGroup, bj_lastCreatedUnit)
        endloop
        call loc.destroy()
        return bj_lastCreatedGroup
    endfunction
    function AngleBetweenPointsEx takes LocEx locA,LocEx locB returns real//�����Ƕ�
        local real y=locB.y-locA.y
        local real x=locB.x-locA.x
        call locB.destroy()
        call locA.destroy()
        return bj_RADTODEG * Atan2(y,x)
    endfunction
    function CreateCorpseLocBJEx takes integer unitid, player p,LocEx loc returns unit//����ʬ��
        set bj_lastCreatedUnit = CreateCorpse(p,unitid,loc.x,loc.y,GetRandomReal(0, 360))
        call loc.destroy()
        return bj_lastCreatedUnit
    endfunction
    function IssuePointOrderLocEx takes unit u,string s,LocEx l returns nothing//���������
        call IssuePointOrder(u,s,l.x,l.y)
        call l.destroy()
    endfunction
    function GetLocationZEx takes LocEx loc returns real//��Z����
        local location l=Location(loc.x,loc.y)
        local real z=GetLocationZ(l)
        call RemoveLocation(l)
        set l=null
        call loc.destroy()
        return z
    endfunction
    function PanCameraToTimedLocForPlayerEx takes player p, LocEx loc, real d returns nothing//�ƶ���ͷ-ָ�����
        if (GetLocalPlayer() == p) then
            call PanCameraToTimed(loc.x,loc.y, d)
        endif
        call loc.destroy()
    endfunction
    function CreateItemLocEx takes integer itemId,LocEx loc returns item//������Ʒ
        set bj_lastCreatedItem = CreateItem(itemId,loc.x,loc.y)
        call loc.destroy()
        return bj_lastCreatedItem
    endfunction
    function SetItemPositionLocEx takes item whichItem,LocEx loc returns nothing//�ƶ���Ʒ
        call SetItemPosition(whichItem,loc.x,loc.y)
        call loc.destroy()
    endfunction
    function ReviveHeroLocEx takes unit u,LocEx l,boolean b returns nothing//����Ӣ��
        call ReviveHero(u,l.x,l.y,b)
        call l.destroy()
    endfunction
    function AddSpecialEffectLocBJEx takes LocEx where, string modelName returns nothing//�½���Ч
	    call DestroyEffect(AddSpecialEffect(modelName,where.x,where.y))
	    call where.destroy()
	endfunction
endlibrary

#endif
