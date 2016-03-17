(function(){var g,k=this;function l(a){a=a.split(".");for(var b=k,c;c=a.shift();)if(null!=b[c])b=b[c];else return null;return b}
function aa(){}
function n(a){var b=typeof a;if("object"==b)if(a){if(a instanceof Array)return"array";if(a instanceof Object)return b;var c=Object.prototype.toString.call(a);if("[object Window]"==c)return"object";if("[object Array]"==c||"number"==typeof a.length&&"undefined"!=typeof a.splice&&"undefined"!=typeof a.propertyIsEnumerable&&!a.propertyIsEnumerable("splice"))return"array";if("[object Function]"==c||"undefined"!=typeof a.call&&"undefined"!=typeof a.propertyIsEnumerable&&!a.propertyIsEnumerable("call"))return"function"}else return"null";
else if("function"==b&&"undefined"==typeof a.call)return"object";return b}
function p(a){var b=n(a);return"array"==b||"object"==b&&"number"==typeof a.length}
function q(a){return"string"==typeof a}
function ba(a){var b=typeof a;return"object"==b&&null!=a||"function"==b}
var r="closure_uid_"+(1E9*Math.random()>>>0),ca=0;function da(a,b,c){return a.call.apply(a.bind,arguments)}
function ea(a,b,c){if(!a)throw Error();if(2<arguments.length){var d=Array.prototype.slice.call(arguments,2);return function(){var c=Array.prototype.slice.call(arguments);Array.prototype.unshift.apply(c,d);return a.apply(b,c)}}return function(){return a.apply(b,arguments)}}
function t(a,b,c){t=Function.prototype.bind&&-1!=Function.prototype.bind.toString().indexOf("native code")?da:ea;return t.apply(null,arguments)}
function u(a,b){var c=a.split("."),d=k;c[0]in d||!d.execScript||d.execScript("var "+c[0]);for(var e;c.length&&(e=c.shift());)c.length||void 0===b?d[e]?d=d[e]:d=d[e]={}:d[e]=b}
function v(a,b){function c(){}
c.prototype=b.prototype;a.L=b.prototype;a.prototype=new c;a.prototype.constructor=a;a.base=function(a,c,f){for(var h=Array(arguments.length-2),m=2;m<arguments.length;m++)h[m-2]=arguments[m];return b.prototype[c].apply(a,h)}}
;var fa=String.prototype.trim?function(a){return a.trim()}:function(a){return a.replace(/^[\s\xa0]+|[\s\xa0]+$/g,"")},ga=/&/g,ha=/</g,ia=/>/g,ka=/"/g,la=/'/g,ma=/\x00/g,na=/[\x00&<>"']/;
function w(a,b){return a<b?-1:a>b?1:0}
;var oa=Array.prototype.indexOf?function(a,b,c){return Array.prototype.indexOf.call(a,b,c)}:function(a,b,c){c=null==c?0:0>c?Math.max(0,a.length+c):c;
if(q(a))return q(b)&&1==b.length?a.indexOf(b,c):-1;for(;c<a.length;c++)if(c in a&&a[c]===b)return c;return-1},x=Array.prototype.forEach?function(a,b,c){Array.prototype.forEach.call(a,b,c)}:function(a,b,c){for(var d=a.length,e=q(a)?a.split(""):a,f=0;f<d;f++)f in e&&b.call(c,e[f],f,a)};
function pa(a,b){var c;a:{c=a.length;for(var d=q(a)?a.split(""):a,e=0;e<c;e++)if(e in d&&b.call(void 0,d[e],e,a)){c=e;break a}c=-1}return 0>c?null:q(a)?a.charAt(c):a[c]}
function qa(a){return Array.prototype.concat.apply(Array.prototype,arguments)}
function y(a){var b=a.length;if(0<b){for(var c=Array(b),d=0;d<b;d++)c[d]=a[d];return c}return[]}
;function ra(a){var b=z,c;for(c in b)if(a.call(void 0,b[c],c,b))return c}
;var A;a:{var sa=k.navigator;if(sa){var ta=sa.userAgent;if(ta){A=ta;break a}}A=""}function B(a){return-1!=A.indexOf(a)}
;var ua=B("Opera")||B("OPR"),C=B("Trident")||B("MSIE"),va=B("Edge"),D=B("Gecko")&&!(-1!=A.toLowerCase().indexOf("webkit")&&!B("Edge"))&&!(B("Trident")||B("MSIE"))&&!B("Edge"),wa=-1!=A.toLowerCase().indexOf("webkit")&&!B("Edge");function xa(){var a=k.document;return a?a.documentMode:void 0}
var E;a:{var ya="",za=function(){var a=A;if(D)return/rv\:([^\);]+)(\)|;)/.exec(a);if(va)return/Edge\/([\d\.]+)/.exec(a);if(C)return/\b(?:MSIE|rv)[: ]([^\);]+)(\)|;)/.exec(a);if(wa)return/WebKit\/(\S+)/.exec(a);if(ua)return/(?:Version)[ \/]?(\S+)/.exec(a)}();
za&&(ya=za?za[1]:"");if(C){var Aa=xa();if(null!=Aa&&Aa>parseFloat(ya)){E=String(Aa);break a}}E=ya}var Ba=E,Ca={};
function Da(a){if(!Ca[a]){for(var b=0,c=fa(String(Ba)).split("."),d=fa(String(a)).split("."),e=Math.max(c.length,d.length),f=0;0==b&&f<e;f++){var h=c[f]||"",m=d[f]||"",qb=RegExp("(\\d*)(\\D*)","g"),rb=RegExp("(\\d*)(\\D*)","g");do{var I=qb.exec(h)||["","",""],J=rb.exec(m)||["","",""];if(0==I[0].length&&0==J[0].length)break;b=w(0==I[1].length?0:parseInt(I[1],10),0==J[1].length?0:parseInt(J[1],10))||w(0==I[2].length,0==J[2].length)||w(I[2],J[2])}while(0==b)}Ca[a]=0<=b}}
var Ea=k.document,Fa=Ea&&C?xa()||("CSS1Compat"==Ea.compatMode?parseInt(Ba,10):5):void 0;var Ga;if(!(Ga=!D&&!C)){var Ha;if(Ha=C)Ha=9<=Number(Fa);Ga=Ha}Ga||D&&Da("1.9.1");C&&Da("9");function Ia(a){var b,c,d,e;b=document;if(b.querySelectorAll&&b.querySelector&&a)return b.querySelectorAll(""+(a?"."+a:""));if(a&&b.getElementsByClassName){var f=b.getElementsByClassName(a);return f}f=b.getElementsByTagName("*");if(a){e={};for(c=d=0;b=f[c];c++){var h=b.className,m;if(m="function"==typeof h.split)m=0<=oa(h.split(/\s+/),a);m&&(e[d++]=b)}e.length=d;return e}return f}
function Ja(a,b){for(var c=0;a;){if(b(a))return a;a=a.parentNode;c++}return null}
;var Ka=k.JSON.parse,La=k.JSON.stringify;function Ma(a){k.setTimeout(function(){throw a;},0)}
var Na;
function Oa(){var a=k.MessageChannel;"undefined"===typeof a&&"undefined"!==typeof window&&window.postMessage&&window.addEventListener&&!B("Presto")&&(a=function(){var a=document.createElement("IFRAME");a.style.display="none";a.src="";document.documentElement.appendChild(a);var b=a.contentWindow,a=b.document;a.open();a.write("");a.close();var c="callImmediate"+Math.random(),d="file:"==b.location.protocol?"*":b.location.protocol+"//"+b.location.host,a=t(function(a){if(("*"==d||a.origin==d)&&a.data==
c)this.port1.onmessage()},this);
b.addEventListener("message",a,!1);this.port1={};this.port2={postMessage:function(){b.postMessage(c,d)}}});
if("undefined"!==typeof a&&!B("Trident")&&!B("MSIE")){var b=new a,c={},d=c;b.port1.onmessage=function(){if(void 0!==c.next){c=c.next;var a=c.N;c.N=null;a()}};
return function(a){d.next={N:a};d=d.next;b.port2.postMessage(0)}}return"undefined"!==typeof document&&"onreadystatechange"in document.createElement("SCRIPT")?function(a){var b=document.createElement("SCRIPT");
b.onreadystatechange=function(){b.onreadystatechange=null;b.parentNode.removeChild(b);b=null;a();a=null};
document.documentElement.appendChild(b)}:function(a){k.setTimeout(a,0)}}
;function Pa(a,b,c){this.j=c;this.h=a;this.l=b;this.f=0;this.c=null}
Pa.prototype.get=function(){var a;0<this.f?(this.f--,a=this.c,this.c=a.next,a.next=null):a=this.h();return a};function Qa(){this.f=this.c=null}
var Sa=new Pa(function(){return new Ra},function(a){a.reset()},100);
Qa.prototype.remove=function(){var a=null;this.c&&(a=this.c,this.c=this.c.next,this.c||(this.f=null),a.next=null);return a};
function Ra(){this.next=this.f=this.c=null}
Ra.prototype.reset=function(){this.next=this.f=this.c=null};function Ta(a){F||Ua();Va||(F(),Va=!0);var b=Wa,c=Sa.get();c.c=a;c.f=void 0;c.next=null;b.f?b.f.next=c:b.c=c;b.f=c}
var F;function Ua(){if(k.Promise&&k.Promise.resolve){var a=k.Promise.resolve(void 0);F=function(){a.then(Xa)}}else F=function(){var a=Xa;
"function"!=n(k.setImmediate)||k.Window&&k.Window.prototype&&!B("Edge")&&k.Window.prototype.setImmediate==k.setImmediate?(Na||(Na=Oa()),Na(a)):k.setImmediate(a)}}
var Va=!1,Wa=new Qa;function Xa(){for(var a=null;a=Wa.remove();){try{a.c.call(a.f)}catch(c){Ma(c)}var b=Sa;b.l(a);b.f<b.j&&(b.f++,a.next=b.c,b.c=a)}Va=!1}
;function G(){this.h=this.h;this.j=this.j}
G.prototype.h=!1;G.prototype.isDisposed=function(){return this.h};
G.prototype.dispose=function(){this.h||(this.h=!0,this.I())};
G.prototype.I=function(){if(this.j)for(;this.j.length;)this.j.shift()()};function H(a){G.call(this);this.A=1;this.l=[];this.m=0;this.c=[];this.f={};this.G=!!a}
v(H,G);g=H.prototype;g.subscribe=function(a,b,c){var d=this.f[a];d||(d=this.f[a]=[]);var e=this.A;this.c[e]=a;this.c[e+1]=b;this.c[e+2]=c;this.A=e+3;d.push(e);return e};
function Ya(a,b,c){var d=K;if(a=d.f[a]){var e=d.c;(a=pa(a,function(a){return e[a+1]==b&&e[a+2]==c}))&&d.M(a)}}
g.M=function(a){var b=this.c[a];if(b){var c=this.f[b];if(0!=this.m)this.l.push(a),this.c[a+1]=aa;else{if(c){var d=oa(c,a);0<=d&&Array.prototype.splice.call(c,d,1)}delete this.c[a];delete this.c[a+1];delete this.c[a+2]}}return!!b};
g.P=function(a,b){var c=this.f[a];if(c){for(var d=Array(arguments.length-1),e=1,f=arguments.length;e<f;e++)d[e-1]=arguments[e];if(this.G)for(e=0;e<c.length;e++){var h=c[e];Za(this.c[h+1],this.c[h+2],d)}else{this.m++;try{for(e=0,f=c.length;e<f;e++)h=c[e],this.c[h+1].apply(this.c[h+2],d)}finally{if(this.m--,0<this.l.length&&0==this.m)for(;c=this.l.pop();)this.M(c)}}return 0!=e}return!1};
function Za(a,b,c){Ta(function(){a.apply(b,c)})}
g.clear=function(a){if(a){var b=this.f[a];b&&(x(b,this.M,this),delete this.f[a])}else this.c.length=0,this.f={}};
g.I=function(){H.L.I.call(this);this.clear();this.l.length=0};var $a=/^(?:([^:/?#.]+):)?(?:\/\/(?:([^/?#]*)@)?([^/#?]*?)(?::([0-9]+))?(?=[/#?]|$))?([^?#]+)?(?:\?([^#]*))?(?:#(.*))?$/;function ab(a,b,c){if("array"==n(b))for(var d=0;d<b.length;d++)ab(a,String(b[d]),c);else null!=b&&c.push("&",a,""===b?"":"=",encodeURIComponent(String(b)))}
function bb(a){var b=[],c;for(c in a)ab(c,a[c],b);b[0]="";return b.join("")}
var cb=/#|$/;var db=l("yt.dom.getNextId_");if(!db){db=function(){return++eb};
u("yt.dom.getNextId_",db);var eb=0};var L=window.yt&&window.yt.config_||window.ytcfg&&window.ytcfg.data_||{};u("yt.config_",L);u("yt.tokens_",window.yt&&window.yt.tokens_||{});var fb=window.yt&&window.yt.msgs_||l("window.ytcfg.msgs")||{};u("yt.msgs_",fb);function gb(a){var b=arguments;if(1<b.length){var c=b[0];L[c]=b[1]}else for(c in b=b[0],b)L[c]=b[c]}
function ib(a){"function"==n(a)&&(a=jb(a));return window.setInterval(a,250)}
function jb(a){return a&&window.yterr?function(){try{return a.apply(this,arguments)}catch(b){throw kb(b),b;}}:a}
function kb(a,b){var c=l("yt.logging.errors.log");c?c(a,b,void 0,void 0):(c=[],c="ERRORS"in L?L.ERRORS:c,c.push([a,b,void 0,void 0]),gb("ERRORS",c))}
;function M(a){this.type="";this.source=this.data=this.currentTarget=this.relatedTarget=this.target=null;this.charCode=this.keyCode=0;this.shiftKey=this.ctrlKey=this.altKey=!1;this.clientY=this.clientX=0;if(a=a||window.event){this.event=a;for(var b in a)b in lb||(this[b]=a[b]);(b=a.target||a.srcElement)&&3==b.nodeType&&(b=b.parentNode);this.target=b;if(b=a.relatedTarget)try{b=b.nodeName?b:null}catch(c){b=null}else"mouseover"==this.type?b=a.fromElement:"mouseout"==this.type&&(b=a.toElement);this.relatedTarget=
b;this.clientX=void 0!=a.clientX?a.clientX:a.pageX;this.clientY=void 0!=a.clientY?a.clientY:a.pageY;this.keyCode=a.keyCode?a.keyCode:a.which;this.charCode=a.charCode||("keypress"==this.type?this.keyCode:0);this.altKey=a.altKey;this.ctrlKey=a.ctrlKey;this.shiftKey=a.shiftKey}}
M.prototype.preventDefault=function(){this.event&&(this.event.returnValue=!1,this.event.preventDefault&&this.event.preventDefault())};
M.prototype.stopPropagation=function(){this.event&&(this.event.cancelBubble=!0,this.event.stopPropagation&&this.event.stopPropagation())};
M.prototype.stopImmediatePropagation=function(){this.event&&(this.event.cancelBubble=!0,this.event.stopImmediatePropagation&&this.event.stopImmediatePropagation())};
var lb={stopImmediatePropagation:1,stopPropagation:1,preventMouseEvent:1,preventManipulation:1,preventDefault:1,layerX:1,layerY:1,scale:1,rotation:1,webkitMovementX:1,webkitMovementY:1};var z=l("yt.events.listeners_")||{};u("yt.events.listeners_",z);var nb=l("yt.events.counter_")||{count:0};u("yt.events.counter_",nb);function ob(a,b,c){a.addEventListener&&("mouseenter"!=b||"onmouseenter"in document?"mouseleave"!=b||"onmouseenter"in document?"mousewheel"==b&&"MozBoxSizing"in document.documentElement.style&&(b="MozMousePixelScroll"):b="mouseout":b="mouseover");return ra(function(d){return d[0]==a&&d[1]==b&&d[2]==c&&0==d[4]})}
function pb(a,b,c){if(a&&(a.addEventListener||a.attachEvent)){var d=ob(a,b,c);if(!d){var d=++nb.count+"",e=!("mouseenter"!=b&&"mouseleave"!=b||!a.addEventListener||"onmouseenter"in document),f;f=e?function(d){d=new M(d);if(!Ja(d.relatedTarget,function(b){return b==a}))return d.currentTarget=a,d.type=b,c.call(a,d)}:function(b){b=new M(b);
b.currentTarget=a;return c.call(a,b)};
f=jb(f);a.addEventListener?("mouseenter"==b&&e?b="mouseover":"mouseleave"==b&&e?b="mouseout":"mousewheel"==b&&"MozBoxSizing"in document.documentElement.style&&(b="MozMousePixelScroll"),a.addEventListener(b,f,!1)):a.attachEvent("on"+b,f);z[d]=[a,b,c,f,!1]}}}
function sb(a){a&&("string"==typeof a&&(a=[a]),x(a,function(a){if(a in z){var c=z[a],d=c[0],e=c[1],f=c[3],c=c[4];d.removeEventListener?d.removeEventListener(e,f,c):d.detachEvent&&d.detachEvent("on"+e,f);delete z[a]}}))}
;var tb={};function ub(a){return tb[a]||(tb[a]=String(a).replace(/\-([a-z])/g,function(a,c){return c.toUpperCase()}))}
;var N={},vb=[],K=new H,wb={};function xb(){x(vb,function(a){a()})}
function yb(a){var b=y(document.getElementsByTagName("yt:"+a));a="yt-"+a;var c=document;a=c.querySelectorAll&&c.querySelector?c.querySelectorAll("."+a):Ia(a);a=y(a);return qa(b,a)}
function O(a,b){return"yt:"==a.tagName.toLowerCase().substr(0,3)?a.getAttribute(b):a?a.dataset?a.dataset[ub(b)]:a.getAttribute("data-"+b):null}
function zb(a,b){K.P.apply(K,arguments)}
;function P(a,b,c){this.f=b;this.l=this.c=null;this.m=this[r]||(this[r]=++ca);this.h=0;this.J=!1;this.H=[];this.j=null;this.A=c;this.G={};b=document;if(a=q(a)?b.getElementById(a):a)if("iframe"!=a.tagName.toLowerCase()&&(b=Ab(this,a),this.l=a,(c=a.parentNode)&&c.replaceChild(b,a),a=b),this.c=a,this.c.id||(b=a=this.c,b=b[r]||(b[r]=++ca),a.id="widget"+b),N[this.c.id]=this,window.postMessage){this.j=new H;Bb(this);a=Q(this.f,"events");for(var d in a)a.hasOwnProperty(d)&&this.addEventListener(d,a[d]);for(var e in wb)Cb(this,
e)}}
g=P.prototype;g.Z=function(a,b){this.c.width=a;this.c.height=b;return this};
g.Y=function(){return this.c};
g.R=function(a){this.v(a.event,a)};
g.addEventListener=function(a,b){var c=b;"string"==typeof b&&(c=function(){window[b].apply(window,arguments)});
this.j.subscribe(a,c);Db(this,a);return this};
function Cb(a,b){var c=b.split(".");if(2==c.length){var d=c[1];a.A==c[0]&&Db(a,d)}}
g.X=function(){this.c.id&&(N[this.c.id]=null);var a=this.j;a&&"function"==typeof a.dispose&&a.dispose();if(this.l){var a=this.c,b=a.parentNode;b&&b.replaceChild(this.l,a)}else(a=this.c)&&a.parentNode&&a.parentNode.removeChild(a);R&&(R[this.m]=null);this.f=null;var a=this.c,c;for(c in z)z[c][0]==a&&sb(c);this.l=this.c=null};
g.C=function(){return{}};
function S(a,b,c){c=c||[];c=Array.prototype.slice.call(c);b={event:"command",func:b,args:c};a.J?a.K(b):a.H.push(b)}
g.v=function(a,b){if(!this.j.isDisposed()){var c={target:this,data:b};this.j.P(a,c);zb(this.A+"."+a,c)}};
function Ab(a,b){for(var c=document.createElement("iframe"),d=b.attributes,e=0,f=d.length;e<f;e++){var h=d[e].value;null!=h&&""!=h&&"null"!=h&&c.setAttribute(d[e].name,h)}c.setAttribute("frameBorder",0);c.setAttribute("allowfullscreen",1);c.setAttribute("title","YouTube "+Q(a.f,"title"));(d=Q(a.f,"width"))&&c.setAttribute("width",d);(d=Q(a.f,"height"))&&c.setAttribute("height",d);var m=a.C();m.enablejsapi=window.postMessage?1:0;window.location.host&&(m.origin=window.location.protocol+"//"+window.location.host);
window.location.href&&x(["debugjs","debugcss"],function(a){var b;b=window.location.href;var c=b.search(cb),d;b:{d=0;for(var e=a.length;0<=(d=b.indexOf(a,d))&&d<c;){var f=b.charCodeAt(d-1);if(38==f||63==f)if(f=b.charCodeAt(d+e),!f||61==f||38==f||35==f)break b;d+=e+1}d=-1}if(0>d)b=null;else{e=b.indexOf("&",d);if(0>e||e>c)e=c;d+=a.length+1;b=decodeURIComponent(b.substr(d,e-d).replace(/\+/g," "))}null===b||(m[a]=b)});
c.src=Q(a.f,"host")+a.D()+"?"+bb(m);return c}
g.O=function(){this.c&&this.c.contentWindow?this.K({event:"listening"}):window.clearInterval(this.h)};
function Bb(a){Eb(a.f,a,a.m);a.h=ib(t(a.O,a));pb(a.c,"load",t(function(){window.clearInterval(this.h);this.h=ib(t(this.O,this))},a))}
function Db(a,b){a.G[b]||(a.G[b]=!0,S(a,"addEventListener",[b]))}
g.K=function(a){a.id=this.m;a=La(a);var b;b=this.f;var c,d=this.c.src.match($a);c=d[1];var e=d[2],f=d[3],d=d[4],h="";c&&(h+=c+":");f&&(h+="//",e&&(h+=e+"@"),h+=f,d&&(h+=":"+d));c=h;b=0==c.indexOf("https:")?[c]:b.f?[c.replace("http:","https:")]:b.j?[c]:[c,c.replace("http:","https:")];for(c=0;c<b.length;c++)try{this.c.contentWindow.postMessage(a,b[c])}catch(m){if(m.name&&"SyntaxError"==m.name)kb(m,"WARNING");else throw m;}};var T="StopIteration"in k?k.StopIteration:{message:"StopIteration",stack:""};function U(){}
U.prototype.next=function(){throw T;};
U.prototype.B=function(){return this};
function Fb(a){if(a instanceof U)return a;if("function"==typeof a.B)return a.B(!1);if(p(a)){var b=0,c=new U;c.next=function(){for(;;){if(b>=a.length)throw T;if(b in a)return a[b++];b++}};
return c}throw Error("Not implemented");}
function Gb(a,b){if(p(a))try{x(a,b,void 0)}catch(c){if(c!==T)throw c;}else{a=Fb(a);try{for(;;)b.call(void 0,a.next(),void 0,a)}catch(c){if(c!==T)throw c;}}}
function Hb(a){if(p(a))return y(a);a=Fb(a);var b=[];Gb(a,function(a){b.push(a)});
return b}
;function Ib(){}
;function Jb(){}
v(Jb,Ib);Jb.prototype.clear=function(){var a=Hb(this.B(!0)),b=this;x(a,function(a){b.remove(a)})};function V(a){this.c=a}
v(V,Jb);g=V.prototype;g.isAvailable=function(){if(!this.c)return!1;try{return this.c.setItem("__sak","1"),this.c.removeItem("__sak"),!0}catch(a){return!1}};
g.get=function(a){a=this.c.getItem(a);if(!q(a)&&null!==a)throw"Storage mechanism: Invalid value was encountered";return a};
g.remove=function(a){this.c.removeItem(a)};
g.B=function(a){var b=0,c=this.c,d=new U;d.next=function(){if(b>=c.length)throw T;var d=c.key(b++);if(a)return d;d=c.getItem(d);if(!q(d))throw"Storage mechanism: Invalid value was encountered";return d};
return d};
g.clear=function(){this.c.clear()};
g.key=function(a){return this.c.key(a)};function Kb(){var a=null;try{a=window.localStorage||null}catch(b){}this.c=a}
v(Kb,V);function Lb(){var a=null;try{a=window.sessionStorage||null}catch(b){}this.c=a}
v(Lb,V);(new Kb).isAvailable();(new Lb).isAvailable();function Mb(a){return(0==a.search("cue")||0==a.search("load"))&&"loadModule"!=a}
function Nb(a){return 0==a.search("get")||0==a.search("is")}
;var Ob="corp.google.com googleplex.com youtube.com youtube-nocookie.com youtubeeducation.com borg.google.com prod.google.com sandbox.google.com books.googleusercontent.com docs.google.com drive.google.com mail.google.com photos.google.com plus.google.com lh2.google.com picasaweb.google.com play.google.com googlevideo.com talkgadget.google.com survey.g.doubleclick.net youtube.googleapis.com vevo.com".split(" "),Pb="";function W(a){this.h=a||{};this.c={};this.c.host="http://www.youtube.com";this.c.title="";this.j=this.f=!1;a=document.getElementById("www-widgetapi-script");if(this.f=!!("https:"==document.location.protocol||a&&0==a.src.indexOf("https:"))){a=[this.h,window.YTConfig||{},this.c];for(var b=0;b<a.length;b++)a[b].host&&(a[b].host=a[b].host.replace("http://","https://"))}}
var R=null;function Q(a,b){for(var c=[a.h,window.YTConfig||{},a.c],d=0;d<c.length;d++){var e=c[d][b];if(void 0!=e)return e}return null}
function Eb(a,b,c){R||(R={},pb(window,"message",t(a.l,a)));R[c]=b}
W.prototype.l=function(a){var b;(b=a.origin==Q(this,"host"))||((b=a.origin)&&b==Pb?b=!0:(new RegExp("^(https?:)?//([a-z0-9-]{1,63}\\.)*("+Ob.join("|").replace(/\./g,".")+")(:[0-9]+)?([/?#]|$)","i")).test(b)?(Pb=b,b=!0):b=!1);if(b){var c;try{c=Ka(a.data)}catch(d){return}this.j=!0;this.f||0!=a.origin.indexOf("https:")||(this.f=!0);if(a=R[c.id])a.J=!0,a.J&&(x(a.H,a.K,a),a.H.length=0),a.R(c)}};function Qb(a){W.call(this,a);this.c.title="video player";this.c.videoId="";this.c.width=640;this.c.height=360}
v(Qb,W);function X(a,b){var c=new Qb(b);P.call(this,a,c,"player");this.o={};this.F={}}
v(X,P);function Rb(a){if("iframe"!=a.tagName.toLowerCase()){var b=O(a,"videoid");if(b){var c=O(a,"width"),d=O(a,"height");new X(a,{videoId:b,width:c,height:d})}}}
g=X.prototype;g.D=function(){return"/embed/"+Q(this.f,"videoId")};
g.C=function(){var a=Q(this.f,"playerVars");if(a){var b={},c;for(c in a)b[c]=a[c];a=b}else a={};document.referrer&&(a.widget_referrer=document.referrer.substring(0,256));return a};
g.R=function(a){var b=a.event;a=a.info;switch(b){case "apiInfoDelivery":if(ba(a))for(var c in a)this.o[c]=a[c];break;case "infoDelivery":Sb(this,a);break;case "initialDelivery":window.clearInterval(this.h);this.F={};this.o={};Tb(this,a.apiInterface);Sb(this,a);break;default:this.v(b,a)}};
function Sb(a,b){if(ba(b))for(var c in b)a.F[c]=b[c]}
function Tb(a,b){x(b,function(a){this[a]||(Mb(a)?this[a]=function(){this.F={};this.o={};S(this,a,arguments);return this}:Nb(a)?this[a]=function(){var b=0;
0==a.search("get")?b=3:0==a.search("is")&&(b=2);return this.F[a.charAt(b).toLowerCase()+a.substr(b+1)]}:this[a]=function(){S(this,a,arguments);
return this})},a)}
g.ba=function(){var a='<iframe width="'+Q(this.f,"width")+'" height="'+Q(this.f,"height")+'" src="';var b=Q(this.f,"host")+this.D();na.test(b)&&(-1!=b.indexOf("&")&&(b=b.replace(ga,"&amp;")),-1!=b.indexOf("<")&&(b=b.replace(ha,"&lt;")),-1!=b.indexOf(">")&&(b=b.replace(ia,"&gt;")),-1!=b.indexOf('"')&&(b=b.replace(ka,"&quot;")),-1!=b.indexOf("'")&&(b=b.replace(la,"&#39;")),-1!=b.indexOf("\x00")&&(b=b.replace(ma,"&#0;")));return a+b+'" frameborder="0" allowfullscreen></iframe>'};
g.aa=function(a){return this.o.namespaces?a?this.o[a].options||[]:this.o.namespaces||[]:[]};
g.$=function(a,b){if(this.o.namespaces&&a&&b)return this.o[a][b]};function Ub(a){W.call(this,a);this.c.title="Thumbnail";this.c.videoId="";this.c.width=120;this.c.height=68}
v(Ub,W);function Y(a,b){var c=new Ub(b);P.call(this,a,c,"thumbnail")}
v(Y,P);function Vb(a){if("iframe"!=a.tagName.toLowerCase()){var b=O(a,"videoid");if(b){b={videoId:b,events:{}};b.width=O(a,"width");b.height=O(a,"height");b.thumbWidth=O(a,"thumb-width");b.thumbHeight=O(a,"thumb-height");b.thumbAlign=O(a,"thumb-align");var c=O(a,"onclick");c&&(b.events.onClick=c);new Y(a,b)}}}
Y.prototype.D=function(){return"/embed/"+Q(this.f,"videoId")};
Y.prototype.C=function(){return{player:0,thumb_width:Q(this.f,"thumbWidth"),thumb_height:Q(this.f,"thumbHeight"),thumb_align:Q(this.f,"thumbAlign")}};
Y.prototype.v=function(a,b){Y.L.v.call(this,a,b?b.info:void 0)};function Wb(a){W.call(this,a);this.c.host="https://www.youtube.com";this.c.title="upload widget";this.c.width=640;this.c.height=.67*Q(this,"width")}
v(Wb,W);function Z(a,b){var c=new Wb(b);P.call(this,a,c,"upload")}
v(Z,P);g=Z.prototype;g.D=function(){return"/upload_embed"};
g.C=function(){var a={},b=Q(this.f,"webcamOnly");null!=b&&(a.webcam_only=b);return a};
g.v=function(a,b){Z.L.v.call(this,a,b);"onApiReady"==a&&S(this,"hostWindowReady")};
g.S=function(a){S(this,"setVideoDescription",arguments)};
g.U=function(a){S(this,"setVideoKeywords",arguments)};
g.V=function(a){S(this,"setVideoPrivacy",arguments)};
g.T=function(a){S(this,"setVideoDraftPrivacy",arguments)};
g.W=function(a){S(this,"setVideoTitle",arguments)};u("YT.PlayerState.UNSTARTED",-1);u("YT.PlayerState.ENDED",0);u("YT.PlayerState.PLAYING",1);u("YT.PlayerState.PAUSED",2);u("YT.PlayerState.BUFFERING",3);u("YT.PlayerState.CUED",5);u("YT.UploadWidgetEvent.API_READY","onApiReady");u("YT.UploadWidgetEvent.UPLOAD_SUCCESS","onUploadSuccess");u("YT.UploadWidgetEvent.PROCESSING_COMPLETE","onProcessingComplete");u("YT.UploadWidgetEvent.STATE_CHANGE","onStateChange");u("YT.UploadWidgetState.IDLE",0);u("YT.UploadWidgetState.PENDING",1);
u("YT.UploadWidgetState.ERROR",2);u("YT.UploadWidgetState.PLAYBACK",3);u("YT.UploadWidgetState.RECORDING",4);u("YT.UploadWidgetState.STOPPED",5);u("YT.get",function(a){return N[a]});
u("YT.scan",xb);u("YT.subscribe",function(a,b,c){K.subscribe(a,b,c);wb[a]=!0;for(var d in N)Cb(N[d],a)});
u("YT.unsubscribe",function(a,b,c){Ya(a,b,c)});
u("YT.Player",X);u("YT.Thumbnail",Y);u("YT.UploadWidget",Z);P.prototype.destroy=P.prototype.X;P.prototype.setSize=P.prototype.Z;P.prototype.getIframe=P.prototype.Y;P.prototype.addEventListener=P.prototype.addEventListener;X.prototype.getVideoEmbedCode=X.prototype.ba;X.prototype.getOptions=X.prototype.aa;X.prototype.getOption=X.prototype.$;Z.prototype.setVideoDescription=Z.prototype.S;Z.prototype.setVideoKeywords=Z.prototype.U;Z.prototype.setVideoPrivacy=Z.prototype.V;Z.prototype.setVideoTitle=Z.prototype.W;
Z.prototype.setVideoDraftPrivacy=Z.prototype.T;vb.push(function(){var a=yb("player");x(a,Rb)});
vb.push(function(){var a=yb("thumbnail");x(a,Vb)});
"undefined"!=typeof YTConfig&&YTConfig.parsetags&&"onload"!=YTConfig.parsetags||xb();var Xb=l("onYTReady");Xb&&Xb();var Yb=l("onYouTubeIframeAPIReady");Yb&&Yb();var Zb=l("onYouTubePlayerAPIReady");Zb&&Zb();})();
