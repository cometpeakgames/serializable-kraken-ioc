﻿using CometPeak.SerializableKrakenIoc;
using CometPeak.SerializableKrakenIoc.Interfaces;
using System;
using UnityEditor;

namespace CometPeak.SerializableKrakenIoc.Editor {
    [InitializeOnLoad()]
    public static class EditorContext {
        public static IContainer Container { get; set; }

        static EditorContext() {
            Container = new Container();

            FindAndBootstrap();
        }

        public static T GetWindow<T>(string title, bool isUtility) where T : UnityEditor.EditorWindow {
            var window = UnityEditor.EditorWindow.GetWindow<T>(isUtility, title);
            Container.Injector.Inject(window);

            return window;
        }

        public static void FindAndBootstrap() {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                foreach (var type in assembly.GetTypes()) {
                    if (typeof(EditorBootstrap).IsAssignableFrom(type)) {
                        Container.Bootstrap(type);
                    }
                }
            }
        }
    }
}
