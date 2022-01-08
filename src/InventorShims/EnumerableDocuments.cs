﻿using Inventor;
using System.Collections.Generic;
using System.Linq;

namespace InventorShims
{
    public static class EnumerableDocuments
    {
        #region IEnumerable GetDocuments providors

        /// <summary>
        /// Returns an IEnumerable collection of Inventor.Document from a SelectSet object.
        /// </summary>
        /// <param name="selectSet">Inventor.SelectionSet</param>
        /// <returns>IEnumerable<Document></Document></returns>
        /// <exception cref="System.ArgumentNullException">Throws an error if the selection set is empty.</exception>
        public static IEnumerable<Document> GetDocuments(this SelectSet selectSet)
        {
            if (selectSet.Count == 0)
                throw new System.ArgumentNullException("The selection set was empty.");

            foreach (dynamic i in selectSet)
            {
                Document tempDocument = DocumentShim.GetDocumentFromObject(i);

                if (tempDocument is null)
                    continue;

                yield return tempDocument;
            }
        }

        /// <summary>
        /// Returns an IEnumerable collection of Inventor.Document from a DocumentDescriptor object.
        /// </summary>
        /// <param name="dds">Inventor.Document</param>
        /// <returns>IEnumerable<Document></returns>
        public static IEnumerable<Document> GetDocuments(this IEnumerable<DocumentDescriptor> dds)
        {
            foreach (DocumentDescriptor dd in dds)
            {
                if (dd is null)
                    continue;

                yield return (Document)dd.ReferencedDocument;
            }
        }

        #endregion IEnumerable GetDocuments providors

        #region IEnumerable<Document> providers

        public static IEnumerable<Document> GetAllReferencedDocuments(this Document document)
        {
            return (IEnumerable<Document>)document.AllReferencedDocuments;
        }

        public static IEnumerable<Document> GetAllReferencedDocuments(this AssemblyDocument document)
        {
            return (IEnumerable<Document>)document.AllReferencedDocuments;
        }

        public static IEnumerable<Document> GetAllReferencedDocuments(this PresentationDocument document)
        {
            return (IEnumerable<Document>)document.AllReferencedDocuments;
        }

        public static IEnumerable<Document> GetAllReferencedDocuments(this PartDocument document)
        {
            return (IEnumerable<Document>)document.AllReferencedDocuments;
        }

        public static IEnumerable<Document> GetAllReferencedDocuments(this DrawingDocument document)
        {
            return (IEnumerable<Document>)document.AllReferencedDocuments;
        }

        public static IEnumerable<Document> GetReferencedDocuments(this Document document)
        {
            return (IEnumerable<Document>)document.AllReferencedDocuments;
        }

        public static IEnumerable<Document> GetReferencedDocuments(this AssemblyDocument document)
        {
            return (IEnumerable<Document>)document.ReferencedDocuments;
        }

        public static IEnumerable<Document> GetReferencedDocuments(this PresentationDocument document)
        {
            return (IEnumerable<Document>)document.ReferencedDocuments;
        }

        public static IEnumerable<Document> GetReferencedDocuments(this PartDocument document)
        {
            return (IEnumerable<Document>)document.ReferencedDocuments;
        }

        public static IEnumerable<Document> GetReferencedDocuments(this DrawingDocument document)
        {
            return (IEnumerable<Document>)document.ReferencedDocuments;
        }

        public static IEnumerable<Document> GetReferencingDocuments(this AssemblyDocument document)
        {
            return (IEnumerable<Document>)document.ReferencingDocuments;
        }

        public static IEnumerable<Document> GetReferencingDocuments(this PresentationDocument document)
        {
            return (IEnumerable<Document>)document.ReferencingDocuments;
        }

        public static IEnumerable<Document> GetReferencingDocuments(this PartDocument document)
        {
            return (IEnumerable<Document>)document.ReferencingDocuments;
        }

        public static IEnumerable<Document> GetReferencingDocuments(this DrawingDocument document)
        {
            return (IEnumerable<Document>)document.ReferencingDocuments;
        }

        #endregion IEnumerable<Document> providers

        #region IEnumerable<Document> Filters

        public static IEnumerable<AssemblyDocument> AssemblyDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.IsAssembly())
                    yield return (AssemblyDocument)document;
            }

            yield break;
        }

        public static IEnumerable<Document> RemoveAssemblyDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (!document.IsAssembly())
                    yield return document;
            }

            yield break;
        }

        public static IEnumerable<DrawingDocument> DrawingDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.IsDrawing())
                    yield return (DrawingDocument)document;
            }

            yield break;
        }

        public static IEnumerable<Document> RemoveDrawingDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (!document.IsDrawing())
                    yield return document;
            }

            yield break;
        }

        public static IEnumerable<PresentationDocument> PresentationDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.IsPresentation())
                    yield return (PresentationDocument)document;
            }

            yield break;
        }

        public static IEnumerable<Document> RemovePresentationDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (!document.IsPresentation())
                    yield return document;
            }

            yield break;
        }

        public static IEnumerable<PartDocument> PartDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.IsPart())
                    yield return (PartDocument)document;
            }

            yield break;
        }

        public static IEnumerable<Document> RemovePartDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (!document.IsPart())
                    yield return document;
            }

            yield break;
        }

        public static IEnumerable<Document> RemoveNonNativeDocuments(this IEnumerable<Document> documents)
        {
            foreach (Document document in documents)
            {
                if (document.IsForeignModel() || document.IsSat() || document.IsUnknown())
                { }
                else
                {
                    yield return document;
                }
            }

            yield break;
        }

        #endregion IEnumerable<Document> Filters

        #region IEnumerable<DocumentDescriptors> providers

        public static IEnumerable<DocumentDescriptor> GetReferencedDocumentDescriptors(this Document document)
        {
            return (IEnumerable<DocumentDescriptor>)document.ReferencedDocumentDescriptors;
        }

        public static IEnumerable<DocumentDescriptor> GetReferencedDocumentDescriptors(this AssemblyDocument document)
        {
            return (IEnumerable<DocumentDescriptor>)document.ReferencedDocumentDescriptors;
        }

        public static IEnumerable<DocumentDescriptor> GetReferencedDocumentDescriptors(this PresentationDocument document)
        {
            return (IEnumerable<DocumentDescriptor>)document.ReferencedDocumentDescriptors;
        }

        public static IEnumerable<DocumentDescriptor> GetReferencedDocumentDescriptors(this PartDocument document)
        {
            return (IEnumerable<DocumentDescriptor>)document.ReferencedDocumentDescriptors;
        }

        public static IEnumerable<DocumentDescriptor> GetReferencedDocumentDescriptors(this DrawingDocument document)
        {
            return (IEnumerable<DocumentDescriptor>)document.ReferencedDocumentDescriptors;
        }

        #endregion IEnumerable<DocumentDescriptors> providers

        #region IEnumerable Samples

        private static void iEnumerableSmpleCode(this Document document)
        {
            var test = document.GetAllReferencedDocuments()
                .RemoveNonNativeDocuments()
                .Where(s => s.IsModifiable)
                .Where(s => s.IsPart())
                .Where(s => s.ReservedForWriteByMe);

            //apply to each in test
            foreach (var i in test)
            {
                i.SetPropertyValue("Author", "Bob");
            }

            document.SelectSet.GetDocuments()
                .Where(s => s.IsModifiable)
                .PartDocuments()
                .Distinct()
                .ToList()
                .ForEach(d => d.SetAttributeValue("MyAttribSet", "Attribute2", "Value"));

            var justTheAssemblyDocs = document.SelectSet.GetDocuments()
                .AssemblyDocuments();

            var notTheAssemblyDocs = document.GetAllReferencedDocuments()
                .Where(s => !s.IsAssembly());

            var JustCustomCCPartDocs = document.GetAllReferencedDocuments()
                .PartDocuments()
                .Where(d => d.IsCustomContentCenter());

            var JustCustomCCDocs = document.GetAllReferencedDocuments()
                .Where(d => d.IsCustomContentCenter());

            var count = document.GetReferencedDocumentDescriptors()
                .Where(s => !s.ReferenceMissing)
                .Where(s => !s.ReferenceSuppressed)
                .GetDocuments()
                .PartDocuments()
                .Count();
        }

        #endregion IEnumerable Samples
    }
}