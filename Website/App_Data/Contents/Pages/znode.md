---
layout: post
title: Enterprise .NET open-source ecommerce cloud platform. Virto Commerce vs Znode
description: Enterprise .NET open-source ecommerce cloud platform. Virto Commerce vs Znode
date: 2014-01-30
permalink: /pages/znode
tags : 
- znode
- commerce
---
<article role="main" class="main">
	<div class="znode __responsive">
		<h1 class="head-title">Virto Commerce vs Znode Comparison</h1>
		<div class="columns">
			<div class="column">
				<div class="block">
					<h3 class="title">Virto Commerce</h3>
					<p class="text">Developed from 2011 as an enterprise platform with focus on Azure cloud and all the latest technologies available including .NET 4.5, Windows Workflow Foundation, Entity Framework 5, Web API, Elastic Search etc.</p>
				</div>
			</div>
			<div class="column">
				<div class="block">
					<h3 class="title">Znode</h3>
					<p class="text">First created as a starter shopping cart for small to medium businesses. In 2011 ZNode was acquired and now targets enterprise level customers. Despite that, it still runs on older .net framework, uses outdated webforms technology and does not utilize any dependency injection.</p>
				</div>
			</div>
		</div>
		<p class="sub-title">Comparison Table</p>
		<p class="text">Comparison tables contains main differences in two products that are meant to be platforms to develop solutions on .net. This is not a pure feature by feature comparison typically used to compare shopping carts.</p>
		<p class="text">If you want to compare Virto Commerce yourself, please download a full SDK version and try creating a proof of concept project.</p>
		<table>
			<thead>
				<tr>
					<th>Feature</th>
					<th>Virto Commerce 1.7</th>
					<th>ZNode Multifront 7.0</th>
				</tr>
			</thead>
			<tbody>
				<tr>
					<td>Technology Highlights</td>
					<td>
						<ul class="list">
							<li>.NET 4.5</li>
							<li>MVC 4/Razor</li>
							<li>Entity Framework 5</li>
							<li>WPF</li>
							<li>WWF</li>
							<li>WCF Web Services (REST/OData/SOAP)</li>
							<li>Web API</li>
							<li>Elastic Search Server / Lucene</li>
							<li>IoC/Unity</li>
							<li>Azure Cloud</li>
							<li>LINQ support for quering data</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>.NET 4.0</li>
							<li>ASP.NET Web Forms</li>
							<li>WCF Web Services</li>
							<li>No Dependency Injection</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Architecture</td>
					<td>Designed to be extensible without needing to modify any core source code. That is achieved by using Dependency Injection, Interfaces, Windows Workflow Foundation Activities for Business processes. Includes LINQ support for querying data.</td>
					<td>Simple things (Payment Gateways, Shipping Gateways) can be extended, however no dependency injection used. For advanced features source code has to be modified which complicates update process.</td>
				</tr>
				<tr>
					<td>Continuous Deployment/integration</td>
					<td>Includes scripts, PowerShell cmdlets and build scripts developed for Microsoft TFS Build Server and Azure Cloud to enable automated regression testing (uses xUnit framework) and automated deployment to staging and production environment.</td>
					<td>Relies on CVS source code, no build or deployment tools.</td>
				</tr>
				<tr>
					<td>Backend</td>
					<td>Uses native WPF Application with ClickOnce update technology</td>
					<td>Web Form based online application</td>
				</tr>
				<tr>
					<td>Catalog Management</td>
					<td>
						<ul class="list">
							<li>Support for master and virtual catalog</li>
							<li>Set pricing per catalog</li>
							<li>Admin displays hierarchical catalog view with categories and products</li>
							<li>Properties, languages can be configured per catalog</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Single catalog type</li>
							<li>Displays list of categories in a flat view</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Category Management</td>
					<td>
						<ul class="list">
							<li>Provides visual tree view, to manage relations</li>
							<li>Supports custom attributes</li>
							<li>Supports linked categories</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>No tree view, must enter parent category</li>
							<li>No custom attributes support</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Product Management</td>
					<td>
						<ul class="list">
							<li>Supports Products, SKUs/Variations, Bundles, Packages, Dynamic Kits</li>
							<li>Supports associating with multiple categories with per category sorting order defined</li>
							<li>Create unlimited number of associations like cross selling</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Only supports Product and SKU</li>
							<li>Supports associating with multiple categories, however sorting is global, no per category sorting</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Support for SKUs/Variations</td>
					<td>
						<ul class="list">
							<li>Implemented using new product type called SKU/Variation</li>
							<li>Variations are then associated with a product</li>
							<li>Can be extended with custom properties</li>
							<li>Each SKU/Variation has full inventory tracking, price lists etc</li>
							<li>Front end engine then display dropdowns or other controls to present choices for size, color and other variations of the product</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Implemented using Add-On Types</li>
							<li>Limited settings</li>
							<li>Can't be extended using custom attributes</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Pricing</td>
					<td>
						<ul class="list">
							<li>Implemented using price lists</li>
							<li>Multiple price lists can be defined</li>
							<li>Price lists can be assigned based on user behavior, catalog, store, geo location</li>
							<li>Prices are dynamically resolved in runtime based on context</li>
							<li>Prices are not part of the product</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Supports tiered pricing</li>
							<li>Prices are embedded within Product</li>
							<li>Prices can be targeted towards user profile</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Attributes/Properties</td>
					<td>
						<ul class="list">
							<li>Supports strong data types: string, long string, integer, boolean, datetime, decimal, image</li>
							<li>Supports marking property as required</li>
							<li>Supports dictionary and multi value dictionary properties</li>
							<li>Supports setting property as multi language</li>
							<li>Can easily add new properties to an existing product</li>
							<li>Property Sets are defined per catalog</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Only supports strings, no strongly typed values</li>
							<li>Can't add attributes to an existing product (Product Type is not modifiable when associated with atleast one product)</li>
							<li>Can only add Dictionary type attributes</li>
							<li>No support for required or multi value attributes</li>
							<li>Product Types are globally defined</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Template Engine</td>
					<td>
						<ul class="list">
							<li>Templates are not specified in product/category details</li>
							<li>Expression engine is used to specify which template is used to render the product/category</li>
							<li>Support global template, product template can be specified per site, per category, per individual product, based on user behavior, per geo location and many more</li>
							<li>Can be easily integrated with any CMS templating engine</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Template is specified inside product detail and is per category and product</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Promotions</td>
					<td>
						<ul class="list">
							<li>Uses expression builder, with unlimited number of combinations available for promotions</li>
							<li>Supports adding gifts when promotion is met</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Uses built in templates for promotions</li>
							<li>No gift support</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Dynamic content</td>
					<td>
						<ul class="list">
							<li>Ability to market promotions or any other content based on customer context, including geo location, browse history, order history etc</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>Includes static messages support</li>
						</ul>
					</td>
				</tr>
				<tr>
					<td>Fulfillment Module</td>
					<td>
						<ul class="list">
							<li>Ability to create pick/pack lists</li>
							<li>Accept returns and exchanges</li>
							<li>Send shipments</li>
						</ul>
					</td>
					<td>
						<ul class="list">
							<li>No fulfillment support</li>
						</ul>
					</td>
				</tr>
			</tbody>
		</table>
		<a class="button fill exchange" href="">Exchange your Znode licenses for Virto Commerce licenses now!</a>
		<p class="text">1 - cnet download page with original znode posting http://download.cnet.com/Znode-ASP-NET-Storefront/3000-10248_4-179183.html</p>
	</div>
	{% include technologies.html %}
</article>